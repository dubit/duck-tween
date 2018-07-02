using System;
using UnityEngine;
using UnityEngine.UI;

namespace DUCK.Tween
{
	/// <summary>
	/// A UIColorFadeAnimation is used to animate the color of a Graphic over time
	/// </summary>
	public class UIColorFadeAnimation : AbstractColorFadeAnimation
	{
		private readonly Graphic graphic;

		/// <summary>
		/// Creates a new UIColorFadeAnimation
		/// </summary>
		/// <param name="target">The Graphic that will be the target of the animation</param>
		/// <param name="from">The start color of the fade</param>
		/// <param name="to">The end color of the fade</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public UIColorFadeAnimation(Graphic target, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target.gameObject, from, to, duration, easingFunction)
		{
			graphic = target;
		}

		protected override void SetColor(Color color)
		{
			graphic.color = color;
		}
	}
}
