using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	/// <summary>
	/// Animation Collection Extensions and Helpers
	/// </summary>
	public static partial class AnimationCollectionExtensions
	{
		/// <summary>
		/// Adds a ColorFadeAnimation to the animation collection
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="renderer">The renderer who's color will be faded</param>
		/// <param name="from">The start color of the fade</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection ColorFade(this AnimationCollection animationCollection, Renderer renderer, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(renderer.ColorFade(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a ColorFadeToAnimation to the animation collection
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="renderer">The renderer who's color will be faded</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection ColorFadeTo(this AnimationCollection animationCollection, Renderer renderer, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(renderer.ColorFadeTo(to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a FadeAnimation to the animation collection
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="renderer">The renderer who's alpha will be faded</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Fade(this AnimationCollection animationCollection, Renderer renderer, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(renderer.Fade(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a FadeToAnimation to the animation collection
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="renderer">The renderer who's alpha will be faded</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection FadeTo(this AnimationCollection animationCollection, Renderer renderer, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(renderer.FadeTo(to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a FadeAnimation to the animation collection
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="renderer">The renderer who's alpha will be faded</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Fade(this AnimationCollection animationCollection, SpriteRenderer renderer, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(renderer.Fade(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a FadeToAnimation to the animation collection
		/// </summary>
		/// <param name="animationCollection">The animation collection to add to</param>
		/// <param name="renderer">The renderer who's alpha will be faded</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection FadeTo(this AnimationCollection animationCollection, SpriteRenderer renderer, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(renderer.FadeTo(to, duration, easingFunction));
		}
	}
}
