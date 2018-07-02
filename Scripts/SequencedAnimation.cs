using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// SequencedAnimation is used to play a set of animations in sequence.
	/// It will not complete until all child animations in the queue have completed.
	/// </summary>
	public class SequencedAnimation : AnimationCollection
	{
		/// <summary>
		/// Get the current playing animation in the queue.
		/// </summary>
		public AbstractAnimation GetCurrentAnimation()
		{
			return Animations[Mathf.Clamp(NumberOfAnimationsCompleted, 0, Animations.Count -1)];
		}

		protected override void PlayQueuedAnimations()
		{
			// All animations have been removed
			if (Animations.Count == 0)
			{
				Debug.LogError("Aborting Sequenced Animation -- all animations are invalid!");
				Abort();
			}

			if (NumberOfAnimationsCompleted < Animations.Count)
			{
				var nextAnimation = Animations[NumberOfAnimationsCompleted];
				if (nextAnimation.IsValid)
				{
					nextAnimation.Play(HandleCurrentAnimationCompleted, () =>
					{
						if (IsPlaying && !nextAnimation.IsValid)
						{
							RemoveInvalidAnimation(nextAnimation);
						}
					});
				}
				else
				{
					RemoveInvalidAnimation(nextAnimation);
				}
			}
			else if (NumberOfAnimationsCompleted == Animations.Count)
			{
				NotifyAnimationComplete();
			}
		}

		private void HandleCurrentAnimationCompleted()
		{
			NumberOfAnimationsCompleted++;
			PlayQueuedAnimations();
		}

		private void RemoveInvalidAnimation(AbstractAnimation targetAnimation)
		{
			Debug.LogError("Removed an invalid animation from the Sequenced Queue!");
			Animations.Remove(targetAnimation);
			PlayQueuedAnimations();
		}

		public override void Reverse()
		{
			base.Reverse();
			NumberOfAnimationsCompleted = Animations.Count - 1 - NumberOfAnimationsCompleted;
		}
	}
}