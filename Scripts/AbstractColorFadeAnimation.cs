using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// AbstractColorFadeAnimation is an abstraction for all color fade animations to derive from
	/// </summary>
	public abstract class AbstractColorFadeAnimation : TimedAnimation
	{
		private readonly Color from;
		private readonly Color to;

		protected AbstractColorFadeAnimation(GameObject target, Color from, Color to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target, duration, easingFunction)
		{
			this.from = from;
			this.to = to;
		}

		protected override void Refresh(float progress)
		{
			SetColor(Interpolate(from, to, progress));
		}

		protected abstract void SetColor(Color color);
	}
}
