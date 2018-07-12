using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	///	AbstractAnimation is an abstraction for all animations to derive from
	/// </summary>
	public abstract class AbstractAnimation
	{
		/// <summary>
		/// A boolean value which is true if the animation is currently playing
		/// </summary>
		public bool IsPlaying { get; protected set; }

		/// <summary>
		/// A boolean value which is true if the animation is currently looping
		/// </summary>
		public bool IsLooping { get; protected set; }

		/// <summary>
		/// A boolean value which is true if the animation is currently paused
		/// </summary>
		public bool IsPaused { get; protected set; }

		/// <summary>
		/// Is the animation valid? i.e. Does it still have the target reference?
		/// If this is set to false calling Play will end it instantly and notify the callbacks;
		/// If it's in a sequence it will be automatically removed.
		/// </summary>
		public abstract bool IsValid { get; }

		private Action onCompleteCallback;
		private Action onAbortCallback;

		/// <summary>
		/// Simply play the animation
		/// </summary>
		public void Play()
		{
			Play(null);
		}

		/// <summary>
		/// Starts playback of the animation
		/// </summary>
		/// <param name="onComplete">An optional callback invoked when the animation is complete</param>
		/// <param name="onAbort">An optional callback invoked if the animation is aborted</param>
		public virtual void Play(Action onComplete, Action onAbort = null)
		{
			if (!IsValid)
			{
				Debug.LogError("Cannot play animation: Invalid!");
				return;
			}

			onCompleteCallback = onComplete;
			onAbortCallback = onAbort;
			IsPlaying = true;
		}

		/// <summary>
		/// Starts playback of the animation with number of repeats
		/// </summary>
		/// <param name="repeat">The repeat times for the animation. 0 (or less than -1) means no repeat; -1 means infinite loop.</param>
		/// <param name="onRepeat">An optional callback invoked on each repeat is complete</param>
		/// <param name="onAllComplete">An optional callback invoked when all repeats are finished (will call once only)</param>
		/// <param name="onAbort">An optional callback invoked if the animation is aborted</param>
		public void Play(int repeat, Action onRepeat = null, Action onAllComplete = null, Action onAbort = null)
		{
			if (!IsValid)
			{
				Debug.LogError("Cannot play animation: Invalid!");
				return;
			}

			IsLooping = repeat > 0 || repeat == -1;

			Action onRepeatComplete = delegate
			{
				if (onRepeat != null)
				{
					onRepeat();
				}

				if (IsLooping)
				{
					Play(repeat == -1 ? -1 : --repeat, onRepeat, onAllComplete, onAbort);
				}
				// This will only occur when the user called FastForward().
				// Abort an animation wouldn't get this delegate called anyway.
				else if (onAllComplete != null)
				{
					onAllComplete();
				}
			};

			Play(IsLooping ? onRepeatComplete : onAllComplete, onAbort);
		}

		/// <summary>
		/// Aborts the current animation at it's current place
		/// </summary>
		public virtual void Abort()
		{
			IsPlaying = false;
			IsLooping = false;
			IsPaused = false;

			if (onAbortCallback != null)
			{
				onAbortCallback();
			}
		}

		/// <summary>
		/// Fastforwards the animation to the end and stops it, leaving the state of the object
		/// </summary>
		public virtual void FastForward()
		{
			IsPlaying = false;
			IsLooping = false;
			IsPaused = false;
			NotifyAnimationComplete();
		}

		/// <summary>
		/// Pause the animation
		/// </summary>
		public virtual void Pause()
		{
			IsPaused = true;
		}

		/// <summary>
		/// Resume the paused animation.
		/// You should not resume a stopped animation.
		/// </summary>
		public virtual void Resume()
		{
			if (!IsPlaying)
			{
				Debug.LogError("You should not resume an animation which isn't playing!");
			}
			IsPaused = false;
		}

		protected void NotifyAnimationComplete()
		{
			IsPlaying = IsLooping;

			if (onCompleteCallback != null)
			{
				onCompleteCallback();
			}
		}
	}
}

