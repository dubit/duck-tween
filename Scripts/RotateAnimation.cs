using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// A RotateAnimation is used to rotate a game object from one orientation to another over time
	/// </summary>
	public class RotateAnimation : TimedAnimation
	{
		private readonly Vector3 fromAngles;
		private readonly Vector3 toAngles;

		private readonly Quaternion fromQuaternion;
		private readonly Quaternion toQuaternion;

		private readonly bool useEulerAngles;
		private readonly bool willUseLocalRotation;

		/// <summary>
		/// Creates a new RotateAnimation
		/// </summary>
		/// <param name="target">The target GameObject of this animation</param>
		/// <param name="from">The start rotation of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="to">The end rotation of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <param name="useLocalRotation">Indicates if the animation will use localRotation</param>
		public RotateAnimation(GameObject target, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null, bool useLocalRotation = true)
			: base(target, duration, easingFunction)
		{
			fromAngles = from;
			toAngles = to;

			useEulerAngles = true;
			willUseLocalRotation = useLocalRotation;
		}

		/// <summary>
		/// Creates a new RotateAnimation
		/// </summary>
		/// <param name="target">The target GameObject of this animation</param>
		/// <param name="from">The start rotation of the RotateAnimation</param>
		/// <param name="to">The end rotation of the RotateAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <param name="useLocalRotation">Indicates if the animation will use localRotation</param>
		public RotateAnimation(GameObject target, Quaternion from, Quaternion to, float duration = 1f, Func<float, float> easingFunction = null, bool useLocalRotation = true)
			: base(target, duration, easingFunction)
		{
			fromQuaternion = from;
			toQuaternion = to;

			useEulerAngles = false;
			willUseLocalRotation = useLocalRotation;
		}

		protected override void Refresh(float progress)
		{
			var rotation = useEulerAngles ?
				Quaternion.Euler(Interpolate(fromAngles, toAngles, progress)) :
				Interpolate(fromQuaternion, toQuaternion, progress);

			if (willUseLocalRotation)
			{
				TargetObject.transform.localRotation = rotation;
			}
			else
			{
				TargetObject.transform.rotation = rotation;
			}
		}
	}
}