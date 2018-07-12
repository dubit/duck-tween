using System;

namespace DUCK.Tween
{
	/// <summary>
	/// A FunctionCallAnimation is used to call a function.
	/// The intended use case is within an AnimationCollection so functions can be invoked at certain times
	/// </summary>
	public class FunctionCallAnimation : AbstractAnimation
	{
		/// <summary>
		/// Always true since the function (action) cannot be null
		/// </summary>
		public override bool IsValid { get { return true; } }

		private readonly Action action;

		/// <summary>
		/// Instantiates a new FunctionCallAnimation
		/// </summary>
		/// <param name="action">The function to invoke when the animation is played</param>
		public FunctionCallAnimation(Action action)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			this.action = action;
		}

		public override void Play(Action onComplete = null, Action onAbort = null)
		{
			base.Play(onComplete, onAbort);
			action();
			// During the action() above, this animation may get aborted.
			if (IsPlaying)
			{
				NotifyAnimationComplete();
			}
		}
	}
}
