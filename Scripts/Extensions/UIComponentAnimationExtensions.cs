using System;
using UnityEngine;
using UnityEngine.UI;

namespace DUCK.Tween.Extensions
{
	public static class UIComponentAnimationExtensions
	{
		/// <summary>
		/// Creates a new UIFadeAnimation using a CanvasGroup
		/// </summary>
		/// <param name="graphic">The Graphic that will be the target of the animation</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created UIFadeAnimation</returns>
		public static UIFadeAnimation Fade(this Graphic graphic, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new UIFadeAnimation(graphic, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new UIFadeAnimation using a CanvasGroup
		/// </summary>
		/// <param name="graphic">The Graphic that will be the target of the animation</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the created UIFadeAnimation</returns>
		public static DelegateAnimation<UIFadeAnimation> FadeTo(this Graphic graphic, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<UIFadeAnimation>(() =>
				new UIFadeAnimation(graphic, graphic.color.a, to, duration, easingFunction));
			return animation;
		}

		/// <summary>
		/// Creates a new UIFadeAnimation using a CanvasGroup using this Graphic
		/// </summary>
		/// <param name="canvasGroup">The CanvasGroup that will be the target of the animation</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created UIFadeAnimation</returns>
		public static UIFadeAnimation Fade(this CanvasGroup canvasGroup, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new UIFadeAnimation(canvasGroup, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new UIColorFadeAnimation using a CanvasGroup using this Graphic
		/// </summary>
		/// <param name="graphic">The Graphic that will be the target of the animation</param>
		/// <param name="from">The start color of the fade</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created UIColorFadeAnimation</returns>
		public static UIColorFadeAnimation ColorFade(this Graphic graphic, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new UIColorFadeAnimation(graphic, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new UIColorFadeAnimation using a CanvasGroup using this Graphic
		/// </summary>
		/// <param name="graphic">The Graphic that will be the target of the animation</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the created UIColorFadeAnimation</returns>
		public static DelegateAnimation<UIColorFadeAnimation> ColorFadeTo(this Graphic graphic, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<UIColorFadeAnimation>(() =>
				new UIColorFadeAnimation(graphic, graphic.color, to, duration, easingFunction));
			return animation;
		}
	}
}
