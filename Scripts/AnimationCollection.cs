using System;
using System.Collections.Generic;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// AnimationCollection is a type of animation that acts as a container for a set of other animations.
	/// When played, each animation will play in sequence/parallel until all have been completed. An Animation in
	/// an AnimationCollection can also be itself an AnimationCollection
	/// </summary>
	public abstract class AnimationCollection : AbstractAnimation, IAnimationPlaybackControl
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
				foreach (var animation in Animations)
				{
					var playbackControl = animation as IAnimationPlaybackControl;
					if (playbackControl != null)
					{
						playbackControl.AnimationDriver = animationDriver;
					}
				}
			}
		}
		private IAnimationDriver animationDriver;

		public override bool IsValid { get { return Animations.Count > 0; } }

		protected List<AbstractAnimation> Animations { get; private set; }
		protected int NumberOfAnimationsCompleted { get; set; }

		protected AnimationCollection()
		{
			Animations = new List<AbstractAnimation>();
			NumberOfAnimationsCompleted = 0;
		}

		/// <summary>
		/// Adds one or more animations to this AnimationCollection
		/// </summary>
		/// <param name="animations">One or more AbstractAnimations to add to this AnimationCollection</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public AnimationCollection Add(params AbstractAnimation[] animations)
		{
			foreach (var animation in animations)
			{
				var playbackControl = animation as IAnimationPlaybackControl;
				if (playbackControl != null)
				{
					playbackControl.AnimationDriver = AnimationDriver;
				}
				Animations.Add(animation);
			}
			return this;
		}

		/// <summary>
		/// Starts playback of the AnimationCollection starting at the first animation
		/// </summary>
		/// <param name="onComplete">A callback invoked when the AnimationCollection is complete</param>
		/// <param name="onAbort">An optional callback invoked if the AnimationCollection is aborted</param>
		public override void Play(Action onComplete, Action onAbort = null)
		{
			if (!IsValid)
			{
				Debug.LogError("Invalid Animation Collection -- It's Empty!");
				return;
			}

			base.Play(onComplete, onAbort);
			NumberOfAnimationsCompleted = 0;
			PlayQueuedAnimations();
		}

		/// <summary>
		/// Aborts the AnimationCollection
		/// </summary>
		public override void Abort()
		{
			base.Abort();
			foreach (var animation in Animations)
			{
				animation.Abort();
			}
		}

		/// <summary>
		/// Fastforwards the AnimationCollection to the end and stops it.
		/// This will result in each animation in the collection having .FastForward() called on it.
		/// meaning each animation will fast forward, and end up in the state it would be in after the final frame of animation
		/// </summary>
		public override void FastForward()
		{
			if (NumberOfAnimationsCompleted < Animations.Count)
			{
				for (var i = NumberOfAnimationsCompleted; i < Animations.Count; ++i)
				{
					Animations[i].FastForward();
				}

				IsPlaying = false;
				IsLooping = false;
				IsPaused = false;
			}
			else
			{
				base.FastForward();
			}
		}

		/// <summary>
		/// Pause all the animations which is currently playing
		/// </summary>
		public override void Pause()
		{
			base.Pause();
			foreach (var animation in Animations)
			{
				if (animation.IsPlaying)
				{
					animation.Pause();
				}
			}
		}

		/// <summary>
		/// Resume all the paused animations.
		/// </summary>
		public override void Resume()
		{
			base.Resume();
			foreach (var animation in Animations)
			{
				if (animation.IsPlaying)
				{
					animation.Resume();
				}
			}
		}

		public void ScaleTime(float duration)
		{
			foreach (var animation in Animations)
			{
				var playbackControl = animation as IAnimationPlaybackControl;
				if (playbackControl != null)
				{
					playbackControl.ScaleTime(duration);
				}
			}
		}

		public void ChangeSpeed(float multiplier)
		{
			foreach (var animation in Animations)
			{
				var playbackControl = animation as IAnimationPlaybackControl;
				if (playbackControl != null)
				{
					playbackControl.ChangeSpeed(multiplier);
				}
			}
		}

		public virtual void Reverse()
		{
			Animations.Reverse();

			foreach (var animation in Animations)
			{
				var playbackControl = animation as IAnimationPlaybackControl;
				if (playbackControl != null)
				{
					playbackControl.Reverse();
				}
			}
		}

		/// <summary>
		/// This function decides how we handle the animations in the queue (collection).
		/// Override this function for different playback strategies.
		/// </summary>
		protected abstract void PlayQueuedAnimations();
	}
}
