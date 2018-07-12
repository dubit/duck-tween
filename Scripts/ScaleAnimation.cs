using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// A ScaleAnimation is used to scale a GameObject from one scale to another over time
	/// </summary>
	public class ScaleAnimation : TimedAnimation
	{
		private readonly Vector3 from;
		private readonly Vector3 to;

		/// <summary>
		/// Creates a new ScaleAnimation
		/// </summary>
		/// <param name="target">The target GameObject of this Animation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public ScaleAnimation(GameObject target, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target, duration, easingFunction)
		{
			this.from = from;
			this.to = to;
		}

		/// <summary>
		/// Creates a new ScaleAnimation
		/// </summary>
		/// <param name="target">The target GameObject of this Animation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public ScaleAnimation(GameObject target, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(target, duration, easingFunction)
		{
			this.from = new Vector3(from, from, from);
			this.to = new Vector3(to, to, to);
		}

		protected override void Refresh(float progress)
		{
			TargetObject.transform.localScale = Interpolate(from, to, progress);
		}
	}
}
