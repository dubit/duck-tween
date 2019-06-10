namespace DUCK.Tween
{
	/// <summary>
	/// A WaitAnimation is used to add a delay to an animation sequence
	/// </summary>
	public class WaitAnimation : TimedAnimation
	{
		/// <summary>
		/// WaitAnimation only valid when the duration > 0
		/// </summary>
		public override bool IsValid => Duration >= 0f;

		/// <summary>
		/// Creates a new WaitAnimation
		/// </summary>
		/// <param name="duration">The duration in seconds to wait. Defaults to 1f</param>
		public WaitAnimation(float duration = 1f)
		{
			Duration = duration;
		}

		protected override void Refresh(float progress) {}
	}
}
