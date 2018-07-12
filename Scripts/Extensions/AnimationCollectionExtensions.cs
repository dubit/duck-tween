namespace DUCK.Tween.Extensions
{
	public static class AnimationExtensions
	{
		/// <summary>
		/// Aborts an animation if the reference is valid and it is playing.
		/// </summary>
		/// <param name="animation">The target animation</param>
		public static void SafeAbort(this AbstractAnimation animation)
		{
			if (animation != null && animation.IsPlaying)
			{
				animation.Abort();
			}
		}

		/// <summary>
		/// Fast-forwards an animation if the reference is valid and it is running.
		/// </summary>
		/// <param name="animation">The target animation</param>
		public static void SafeFastFowrward(this AbstractAnimation animation)
		{
			if (animation != null && animation.IsPlaying)
			{
				animation.FastForward();
			}
		}
	}
}
