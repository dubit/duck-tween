using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// AbstractFloatAnimation is an abstraction for all float based animations to derive from
	/// </summary>
	public abstract class AbstractFloatAnimation : TimedAnimation
	{
		private readonly float from;
		private readonly float to;

		protected AbstractFloatAnimation(GameObject target, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target, duration, easingFunction)
		{
			this.from = from;
			this.to = to;
		}

		protected override void Refresh(float progress)
		{
			SetValue(Interpolate(from, to, progress));
		}

		protected abstract void SetValue(float alpha);
	}
}
