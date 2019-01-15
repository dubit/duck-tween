using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	public static class RendererAnimationExtensions
	{
		/// <summary>
		/// Creates a new ColorShaderPropertyAnimation using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="from">The start color of the fade</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The RendererColorFadeAnimation created</returns>
		public static ColorShaderPropertyAnimation ColorFade(this Renderer renderer, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new ColorShaderPropertyAnimation(renderer, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new ColorShaderPropertyAnimation using this renderer.
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="shaderProperty">The name of the target shader property</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The RendererFadeAnimation created</returns>
		public static ColorShaderPropertyAnimation ColorFade(this Renderer renderer, string shaderProperty, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new ColorShaderPropertyAnimation(renderer, shaderProperty, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new ColorShaderPropertyAnimation using this renderer.
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="shaderPropertyID">The ID of the target shader property</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The RendererFadeAnimation created</returns>
		public static ColorShaderPropertyAnimation ColorFade(this Renderer renderer, int shaderPropertyID, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new ColorShaderPropertyAnimation(renderer, shaderPropertyID, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new ColorShaderPropertyAnimation (in a DelegateAnimation) using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the created RendererColorFadeAnimation</returns>
		public static DelegateAnimation<ColorShaderPropertyAnimation> ColorFadeTo(this Renderer renderer, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return renderer.ColorFadeTo(Shader.PropertyToID("_Color"), to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new ColorShaderPropertyAnimation (in a DelegateAnimation) using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="shaderProperty">The name of the target shader property</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the created RendererColorFadeAnimation</returns>
		public static DelegateAnimation<ColorShaderPropertyAnimation> ColorFadeTo(this Renderer renderer, string shaderProperty, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return renderer.ColorFadeTo(Shader.PropertyToID(shaderProperty), to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new ColorShaderPropertyAnimation (in a DelegateAnimation) using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="shaderPropertyID">The ID of the target shader property</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the created RendererColorFadeAnimation</returns>
		public static DelegateAnimation<ColorShaderPropertyAnimation> ColorFadeTo(this Renderer renderer, int shaderPropertyID, Color to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<ColorShaderPropertyAnimation>(() =>
				new ColorShaderPropertyAnimation(renderer, shaderPropertyID, renderer.material.GetColor(shaderPropertyID), to, duration, easingFunction));
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

		/// <summary>
		/// Creates a new SpriteRendererFadeAnimation using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The RendererFadeAnimation created</returns>
		public static SpriteRendererFadeAnimation Fade(this SpriteRenderer renderer, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new SpriteRendererFadeAnimation(renderer, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new SpriteRendererFadeAnimation (in a DelegateAnimation) using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the RendererFadeAnimation</returns>
		public static DelegateAnimation<SpriteRendererFadeAnimation> FadeTo(this SpriteRenderer renderer, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<SpriteRendererFadeAnimation>(() =>
				new SpriteRendererFadeAnimation(renderer, renderer.color.a, to, duration, easingFunction));
			return animation;
		}

		/// <summary>
		/// Creates a new FloatShaderPropertyAnimation using this renderer.
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="shaderProperty">The name of the target shader property</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The RendererFadeAnimation created</returns>
		public static FloatShaderPropertyAnimation Fade(this Renderer renderer, string shaderProperty, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new FloatShaderPropertyAnimation(renderer, Shader.PropertyToID(shaderProperty), from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new FloatShaderPropertyAnimation using this renderer.
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="shaderPropertyID">The ID of the target shader property</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The RendererFadeAnimation created</returns>
		public static FloatShaderPropertyAnimation Fade(this Renderer renderer, int shaderPropertyID, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new FloatShaderPropertyAnimation(renderer, shaderPropertyID, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new FloatShaderPropertyAnimation (in a DelegateAnimation) using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="shaderProperty">The name of the target shader property</param>
		/// <param name="to">The end value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the created RendererColorFadeAnimation</returns>
		public static DelegateAnimation<FloatShaderPropertyAnimation> FadeTo(this Renderer renderer, string shaderProperty, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return renderer.FadeTo(Shader.PropertyToID(shaderProperty), to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new FloatShaderPropertyAnimation (in a DelegateAnimation) using this renderer
		/// </summary>
		/// <param name="renderer">The renderer that will be the target of the animation</param>
		/// <param name="shaderPropertyID">The ID of the target shader property</param>
		/// <param name="to">The end value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>A DelegateAnimation which contains the created RendererColorFadeAnimation</returns>
		public static DelegateAnimation<FloatShaderPropertyAnimation> FadeTo(this Renderer renderer, int shaderPropertyID, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<FloatShaderPropertyAnimation>(() =>
				new FloatShaderPropertyAnimation(renderer, shaderPropertyID, renderer.material.GetFloat(shaderPropertyID), to, duration, easingFunction));
			return animation;
		}
	}
}
