using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// ParalleledAnimation is used to play a set of animations in parallel.
	/// The animations maybe different durations, or sequences themselves.
	/// It will not complete until all child animations in the queue have completed.
	/// </summary>
	public class ParalleledAnimation : AnimationCollection
	{
		protected override void PlayQueuedAnimations()
		{
			for (var i = Animations.Count - 1; i >= 0; --i)
			{
				var animation = Animations[i];
				if (animation.IsValid)
				{
					animation.Play(HandleEachAnimationCompleted, () =>
					{
						if (IsPlaying && !animation.IsValid)
						{
							RemoveInvalidAnimation(animation);
						}
					});
				}
				else
				{
					RemoveInvalidAnimation(animation);
				}
			}

			// All animations have been removed
			if (Animations.Count == 0)
			{
				Debug.LogError("Aborting Parallelled Animation -- all animations are invalid!");
				Abort();
			}
		}

		private void HandleEachAnimationCompleted()
		{
			// Bump up the number and check if all the animations are finished or not
			if (++NumberOfAnimationsCompleted == Animations.Count)
			{
				NotifyAnimationComplete();
			}
		}

		private void RemoveInvalidAnimation(AbstractAnimation targetAnimation)
		{
			Debug.LogError("Removed an invalid animation from the Paralleled Queue!");
			Animations.Remove(targetAnimation);
		}
	}
}
