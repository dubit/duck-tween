using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	public static class RendererAnimationExtensions
	{
		/// <summary>
		/// Creates a new RendererColorFadeAnimation using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="from">The start color of the fade</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The RendererColorFadeAnimation created</returns>
		public static RendererColorFadeAnimation ColorFade(this Renderer renderer, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new RendererColorFadeAnimation(renderer, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new RendererColorFadeAnimation (in a DelegateAnimation) using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the created RendererColorFadeAnimation</returns>
		public static DelegateAnimation<RendererColorFadeAnimation> ColorFadeTo(this Renderer renderer, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<RendererColorFadeAnimation>(() =>
				new RendererColorFadeAnimation(renderer, renderer.material.color, to, duration, easingFunction));
			return animation;
		}

		/// <summary>
		/// Creates a new RendererFadeAnimation using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The RendererFadeAnimation created</returns>
		public static RendererFadeAnimation Fade(this Renderer renderer, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new RendererFadeAnimation(renderer, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new RendererFadeAnimation (in a DelegateAnimation) using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the RendererFadeAnimation</returns>
		public static DelegateAnimation<RendererFadeAnimation> FadeTo(this Renderer renderer, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<RendererFadeAnimation>(() =>
				new RendererFadeAnimation(renderer, renderer.material.color.a, to, duration, easingFunction));
			return animation;
		}
	}
}
