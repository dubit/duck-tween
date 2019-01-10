using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// A ColorShaderPropertyAnimation is used to animate the color of a specific color shader property over time
	/// </summary>
	public class ColorShaderPropertyAnimation : AbstractColorFadeAnimation
	{
		private readonly Renderer renderer;
		private readonly int shaderPropertyID;

		/// <summary>
		/// Creates a new ColorShaderPropertyAnimation using the main colour of the material
		/// </summary>
		/// <param name="target">The renderer that will be the target of the animation</param>
		/// <param name="from">The start color of the fade</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public ColorShaderPropertyAnimation(Renderer target, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
			: this(target, Shader.PropertyToID("_Color"), from, to, duration, easingFunction)
		{
		}

		/// <summary>
		/// Creates a new ColorShaderPropertyAnimation using a string for the property name
		/// </summary>
		/// <param name="target">The renderer that will be the target of the animation</param>
		/// <param name="propertyName">The name of the shader property that will changed through the animation</param>
		/// <param name="from">The start color of the fade</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public ColorShaderPropertyAnimation(Renderer target, string propertyName,  Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
			: this(target, Shader.PropertyToID(propertyName), from, to, duration, easingFunction)
		{
		}

		/// <summary>
		/// Creates a new ColorShaderPropertyAnimation using an ID for the property.
		/// </summary>
		/// <param name="target">The renderer that will be the target of the animation</param>
		/// <param name="propertyID">The ID of the shader property that will changed through the animation</param>
		/// <param name="from">The start color of the fade</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public ColorShaderPropertyAnimation(Renderer target, int propertyID, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target.gameObject, from, to, duration, easingFunction)
		{
			renderer = target;
			shaderPropertyID = propertyID;
		}

		protected override void SetColor(Color color)
		{
			renderer.material.SetColor(shaderPropertyID, color);
		}
	}
}
