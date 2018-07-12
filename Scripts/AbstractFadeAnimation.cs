using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// AbstractFadeAnimation is an abstraction for all fade animations to derive from
	/// </summary>
	public abstract class AbstractFadeAnimation : TimedAnimation
	{
		private readonly float from;
		private readonly float to;

		protected AbstractFadeAnimation(GameObject target, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target, duration, easingFunction)
		{
			this.from = from;
			this.to = to;
		}

		protected override void Refresh(float progress)
		{
			SetAlpha(Interpolate(from, to, progress));
		}

		protected abstract void SetAlpha(float alpha);
	}
}
