namespace DUCK.Tween
{
	internal interface IAnimationPlaybackControl
	{
		/// <summary>
		/// The animation driver has the responsibility that updating all TimedAnimation.
		/// You can also assign a customised Animation Driver to replace the default one for each individual instance of the animations.
		/// </summary>
		IAnimationDriver AnimationDriver { get; set; }

		/// <summary>
		/// Set the animation duration and also keep the current progress.
		/// i.e. ScaleTime(5.0f) will change a 1.0s/2.0s animation to a 2.5s/5.0s animation.
		/// This function actually doing the same thing of "change the animation playback speed".
		/// </summary>
		/// <param name="duration">The new duration of the animation.</param>
		void ScaleTime(float duration);

		/// <summary>
		/// A little helper for changing the animation playback speed.
		/// It will not change the actual delta time but actually scale the duration of the animation.
		/// This function actually doing the same thing of "scale the animation time".
		/// </summary>
		/// <param name="multiplier">The animation playback speed ratio.</param>
		void ChangeSpeed(float multiplier);

		/// <summary>
		/// Completely reverse the original animation.
		/// It can makes the animation play in between "forward" and "backward" at any point.
		/// </summary>
		void Reverse();
	}
}