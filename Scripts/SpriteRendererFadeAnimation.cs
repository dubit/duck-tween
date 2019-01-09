using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// A SpriteRendererFadeAnimation is used to animate the alpha of a Sprite Renderer over time
	/// </summary>
	public class SpriteRendererFadeAnimation : AbstractFloatAnimation
	{
		private readonly SpriteRenderer renderer;

		/// <summary>
		/// Creates a new SpriteRendererFadeAnimation
		/// </summary>
		/// <param name="target">The renderer that will be the target of the animation</param>
		/// <param name="from">The start alpha value of the fade</param>
		/// <param name="to">The end alpha value of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public SpriteRendererFadeAnimation(SpriteRenderer target, float from, float to, float duration = 1, Func<float, float> easingFunction = null)
			: base(target.gameObject, from, to, duration, easingFunction)
		{
			renderer = target;
		}

		protected override void SetValue(float alpha)
		{
			var color = renderer.color;
			color.a = alpha;
			renderer.color = color;
		}
	}
}