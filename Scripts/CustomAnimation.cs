﻿using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// Custom Animation will simply supplies the interpolated value to the user via an Action function.
	/// </summary>
	public class CustomAnimation : TimedAnimation
	{
		public float CurrentValue { get; private set; }
		public float From { get; set; }
		public float To { get; set; }

		/// <summary>
		/// Custom Animation checks nothing since it's highly customisable
		/// </summary>
		public override bool IsValid => true;

		private readonly Action<float> customUpdate;

		/// <summary>
		/// Create a new Custom Animation.
		/// The interpolated value will be passed into the custom update function.
		/// </summary>
		/// <param name="customUpdate">A Custom Update function</param>
		/// <param name="from">From value</param>
		/// <param name="to">To value</param>
		/// <param name="duration">Duration of the animation</param>
		/// <param name="easingFunction">The easing function for the interpolation</param>
		public CustomAnimation(Action<float> customUpdate, float from = 0, float to = 1.0f, float duration = 1.0f, Func<float, float> easingFunction = null)
			: base((GameObject)null, duration, easingFunction)
		{
			this.customUpdate = customUpdate ?? throw new ArgumentNullException(nameof(customUpdate));
			From = CurrentValue = from;
			To = to;
		}

		protected override void Refresh(float progress)
		{
			customUpdate(CurrentValue = Interpolate(From, To, progress));
		}
	}

	/// <summary>
	/// Custom Animation will simply supplies the interpolated value to the user via an Action function.
	/// </summary>
	public class CustomAnimation<T> : TimedAnimation
	{
		public T Target { get; set; }
		public float CurrentValue { get; private set; }
		public float From { get; set; }
		public float To { get; set; }

		/// <summary>
		/// Custom Animation checks nothing since it's highly customisable
		/// </summary>
		public override bool IsValid => true;

		private readonly Action<T, float> customUpdate;

		/// <summary>
		/// Create a new Custom Animation.
		/// The interpolated value will be passed into the custom update function.
		/// </summary>
		/// <param name="target">The target object</param>
		/// <param name="customUpdate">A Custom Update function</param>
		/// <param name="from">From value</param>
		/// <param name="to">To value</param>
		/// <param name="duration">Duration of the animation</param>
		/// <param name="easingFunction">The easing function for the interpolation</param>
		public CustomAnimation(T target, Action<T, float> customUpdate, float from = 0, float to = 1.0f, float duration = 1.0f, Func<float, float> easingFunction = null)
			: base((GameObject)null, duration, easingFunction)
		{
			Target = target;
			this.customUpdate = customUpdate ?? throw new ArgumentNullException(nameof(customUpdate));
			From = CurrentValue = from;
			To = to;
		}

		protected override void Refresh(float progress)
		{
			customUpdate(Target, CurrentValue = Interpolate(From, To, progress));
		}
	}
}