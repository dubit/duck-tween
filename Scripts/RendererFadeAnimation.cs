using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// A RendererFadeAnimation is used to animate the alpha of a Renderer over time
	/// </summary>
	public class RendererFadeAnimation : AbstractFadeAnimation
	{
		private readonly Renderer renderer;

		/// <summary>
		/// Creates a new RendererFadeAnimation
		/// </summary>
		/// <param name="target">The renderer that will be the target of the animation</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public RendererFadeAnimation(Renderer target, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target.gameObject, from, to, duration, easingFunction)
		{
			renderer = target;
		}

		protected override void SetAlpha(float alpha)
		{
			var color = renderer.material.color;
			color.a = alpha;
			renderer.material.color = color;
		}
	}
}
