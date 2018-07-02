using System;
using UnityEngine;

namespace DUCK.Tween
{
	public abstract class DelegateAnimation : AbstractAnimation, IAnimationPlaybackControl
	{
		public IAnimationDriver AnimationDriver
		{
			get
			{
				return animationDriver ?? (animationDriver = TimedAnimation.DefaultDriver ?? DefaultAnimationDriver.Instance);
			}
			set
			{
				animationDriver = value;
				var playbackControl = Animation as IAnimationPlaybackControl;
				if (playbackControl != null)
				{
					playbackControl.AnimationDriver = animationDriver;
				}
			}
		}
		private IAnimationDriver animationDriver;

		/// <summary>
		/// The embeded animation.
		/// </summary>
		public AbstractAnimation Animation { get; protected set; }

		/// <summary>
		/// The simple callback when the animation has been created.
		/// </summary>
		public Action<AbstractAnimation> OnAnimationCreated { protected get; set; }

		/// <summary>
		/// Returns the type of the inner animation.
		/// </summary>
		public abstract Type InnerAnimationType { get; }

		// Both ScaleTime() and ChangeSpeed() are doing the same thing, so they are sharing this callback
		protected Action speedChangeRequest;
		protected Action reverseChangeRequest;

		public void ScaleTime(float duration)
		{
			if (Animation == null)
			{
				speedChangeRequest = () => ScaleInnerAnimationTime(duration);
			}
			else
			{
				ScaleInnerAnimationTime(duration);
			}
		}

		public void ChangeSpeed(float multiplier)
		{
			if (Animation == null)
			{
				speedChangeRequest = () => ChangeInnerAnimationSpeed(multiplier);
			}
			else
			{
				ChangeInnerAnimationSpeed(multiplier);
			}
		}

		public void Reverse()
		{
			if (Animation == null)
			{
				reverseChangeRequest = ReverseInnerAnimation;
			}
			else
			{
				ReverseInnerAnimation();
			}
		}

		private void ScaleInnerAnimationTime(float duration)
		{
			var playbackControl = Animation as IAnimationPlaybackControl;
			if (playbackControl != null)
			{
				playbackControl.ScaleTime(duration);
			}
		}

		private void ChangeInnerAnimationSpeed(float multiplier)
		{
			var playbackControl = Animation as IAnimationPlaybackControl;
			if (playbackControl != null)
			{
				playbackControl.ChangeSpeed(multiplier);
			}
		}

		private void ReverseInnerAnimation()
		{
			var playbackControl = Animation as IAnimationPlaybackControl;
			if (playbackControl != null)
			{
				playbackControl.Reverse();
			}
		}
	}

	/// <summary>
	/// Encapsulates an AbstractAnimation, which is only created at the time it is requested to play.
	/// Useful for AbstractAnimations which depend on an object being in a certain state other than the state in which the abstractAnimations are originally created
	/// </summary>
	public sealed class DelegateAnimation<T> : DelegateAnimation where T : AbstractAnimation
	{
		public new T Animation { get { return (T)base.Animation; } set { base.Animation = value; } }

		public override Type InnerAnimationType { get { return typeof(T); } }

		/// <summary>
		/// Delegate animation is always valid before you created the child animation;
		/// Then the validation will be relied on the created animation.
		/// </summary>
		public override bool IsValid { get { return Animation == null || Animation.IsValid; } }

		private readonly Func<T> animationCreationFunction;

		/// <summary>
		/// Creates a new DelegateAnimation
		/// </summary>
		/// <param name="animationCreationFunction">A function that will create the animation when called</param>
		public DelegateAnimation(Func<T> animationCreationFunction)
		{
			if (animationCreationFunction == null)
			{
				throw new ArgumentNullException("animationCreationFunction");
			}
			this.animationCreationFunction = animationCreationFunction;
		}

		public override void Play(Action onComplete, Action onAbort = null)
		{
			base.Play(onComplete, onAbort);

			try
			{
				Animation = animationCreationFunction();

				var playbackControl = Animation as IAnimationPlaybackControl;
				if (playbackControl != null)
				{
					playbackControl.AnimationDriver = AnimationDriver;
				}

				if (speedChangeRequest != null)
				{
					speedChangeRequest.Invoke();
				}

				if (reverseChangeRequest != null)
				{
					reverseChangeRequest.Invoke();
				}

				if (OnAnimationCreated != null)
				{
					OnAnimationCreated.Invoke(Animation);
				}

				if (Animation.IsValid)
				{
					Animation.Play(NotifyAnimationComplete, base.Abort);
				}
				else
				{
					base.Abort();
				}
			}
			catch (MissingReferenceException e)
			{
				Debug.LogWarning("DelegateAnimation: Your GameObject has probably been destroyed!");
				Debug.LogWarning(e.Message);
				base.FastForward();
			}
			catch (Exception)
			{
				Debug.LogError("DelegateAnimation: Cannot create your animation!");
				throw;
			}
		}

		public override void Abort()
		{
			if (Animation != null)
			{
				Animation.Abort();
			}
		}

		public override void FastForward()
		{
			if (Animation != null)
			{
				Animation.FastForward();
			}
			else
			{
				Debug.LogError("DelegateAnimation: You cannot fast forward because you haven't started your delegate animation yet!");
			}
			base.FastForward();
		}

		public override void Pause()
		{
			base.Pause();
			if (Animation != null)
			{
				Animation.Pause();
			}
		}

		public override void Resume()
		{
			base.Resume();
			if (Animation != null)
			{
				Animation.Resume();
			}
			else
			{
				Debug.LogError("DelegateAnimation: You cannot resume this animation because you haven't started your delegate animation yet!");
			}
		}
	}
}