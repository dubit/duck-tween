using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// A RendererColorFadeAnimation is used to animate the color of a Renderer over time
	/// </summary>
	public class RendererColorFadeAnimation : AbstractColorFadeAnimation
	{
		private readonly Renderer renderer;

		/// <summary>
		/// Creates a new RendererColorFadeAnimation
		/// </summary>
		/// <param name="target">The renderer that will be the target of the animation</param>
		/// <param name="from">The start color of the fade</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public RendererColorFadeAnimation(Renderer target, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target.gameObject, from, to, duration, easingFunction)
		{
			renderer = target;
		}

		protected override void SetColor(Color color)
		{
			renderer.material.color = color;
		}
	}
}
