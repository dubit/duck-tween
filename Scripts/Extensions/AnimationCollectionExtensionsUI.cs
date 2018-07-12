using System;
using UnityEngine;
using UnityEngine.UI;

namespace DUCK.Tween.Extensions
{
	/// <summary>
	/// Animation Collection Extensions and Helpers
	/// </summary>
	public static partial class AnimationCollectionExtensions
	{
		/// <summary>
		/// Adds a UIFadeAnimation to the collection using a Graphic
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="graphic">The Graphic who's alpha will be faded</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Fade(this AnimationCollection animationCollection, Graphic graphic, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(graphic.Fade(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a UIFadeAnimation to the collection using a Graphic
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="graphic">The Graphic who's alpha will be faded</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection FadeTo(this AnimationCollection animationCollection, Graphic graphic, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(graphic.FadeTo(to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a UIFadeAnimation to the collection using a CanvasGroup
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="canvasGroup">The CanvasGroup who's alpha will be faded</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Fade(this AnimationCollection animationCollection, CanvasGroup canvasGroup, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(canvasGroup.Fade(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a UIColorFadeAnimation to the collection using a Graphic
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="graphic">The Graphic who's alpha will be faded</param>
		/// <param name="from">The start color value of the fade</param>
		/// <param name="to">The end color value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection ColorFade(this AnimationCollection animationCollection, Graphic graphic, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(graphic.ColorFade(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a UIColorFadeAnimation to the collection using a Graphic
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="graphic">The Graphic who's alpha will be faded</param>
		/// <param name="to">The end color value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection ColorFadeTo(this AnimationCollection animationCollection, Graphic graphic, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(graphic.ColorFadeTo(to, duration, easingFunction));
		}
	}
}
