using System;

namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Combines multiple easing functions to create a compound easing function
		/// </summary>
		/// <param name="easingFuncs">A collection of easing functions to combine</param>
		/// <returns>A compound easing function ready to be used in a tween</returns>
		public static Func<float, float> Combine(params Func<float, float>[] easingFuncs)
		{
			return t =>
			{
				foreach (var easingFunc in easingFuncs)
				{
					t = easingFunc(t);
				}

				return t;
			};
		}
	}
}