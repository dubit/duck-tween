using System;
using UnityEngine;
using UnityEngine.UI;

namespace DUCK.Tween
{
	/// <summary>
	/// A UIFadeAnimation is used to animate the alpha of a CanvasGroup or Graphic over time
	/// </summary>
	public class UIFadeAnimation : AbstractFadeAnimation
	{
		private readonly CanvasGroup canvasGroup;
		private readonly Graphic graphic;

		/// <summary>
		/// Creates a new UIFadeAnimation using a CanvasGroup
		/// </summary>
		/// <param name="target">The CanvasGroup that will be the target of the animation</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public UIFadeAnimation(CanvasGroup target, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target.gameObject, from, to, duration, easingFunction)
		{
			canvasGroup = target;
		}

		/// <summary>
		/// Creates a new UIFadeAnimation using a Graphic
		/// </summary>
		/// <param name="target">The Graphic that will be the target of the animation</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public UIFadeAnimation(Graphic target, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target.gameObject, from, to, duration, easingFunction)
		{
			graphic = target;
		}

		protected override void SetAlpha(float alpha)
		{
			if (canvasGroup)
			{
				canvasGroup.alpha = alpha;
			}
			if (graphic != null)
			{
				var color = graphic.color;
				color.a = alpha;
				graphic.color = color;
			}
		}
	}
}
