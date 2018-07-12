using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	public static partial class TransformAnimationExtensions
	{
		/// <summary>
		/// Creates a RotateAnimation using this transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="from">The start rotation of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="to">The end rotation of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created RotateAnimation</returns>
		public static RotateAnimation Rotate(this Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new RotateAnimation(transform.gameObject, from, to, duration, easingFunction, false);
		}
		/// <summary>
		/// Creates a RotateAnimation using this transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="from">The start rotation of the RotateAnimation</param>
		/// <param name="to">The end rotation of the RotateAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created RotateAnimation</returns>
		public static RotateAnimation Rotate(this Transform transform, Quaternion from, Quaternion to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new RotateAnimation(transform.gameObject, from, to, duration, easingFunction, false);
		}

		/// <summary>
		/// Creates a RotateAnimation that uses localRotation using this transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="from">The start rotation (local) of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="to">The end rotation (local) of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly create RotateAnimation</returns>
		public static RotateAnimation RotateLocal(this Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new RotateAnimation(transform.gameObject, from, to, duration, easingFunction);
		}
		/// <summary>
		/// Creates a RotateAnimation that uses localRotation using this transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="from">The start rotation (local) of the RotateAnimation</param>
		/// <param name="to">The end rotation (local) of the RotateAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly create RotateAnimation</returns>
		public static RotateAnimation RotateLocal(this Transform transform, Quaternion from, Quaternion to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new RotateAnimation(transform.gameObject, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a RotateAnimation that will rotate from the transform's current rotation to the specified rotation
		/// The current rotation will be the transform's rotation when the animation playback commences and not the rotation at the time of the creation of the animation
		/// </summary>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="to">The end rotation (local) of the RotateAnimation, expressed in eulerAngles</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <param name="useLocalRotation">Indicates if the animation will use localRotation</param>
		/// <returns>The newly created RotateAnimation</returns>
		public static DelegateAnimation<RotateAnimation> RotateTo(this Transform transform, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null, bool useLocalRotation = false)
		{
			var animation = new DelegateAnimation<RotateAnimation>(() =>
				new RotateAnimation(
					transform.gameObject,
					useLocalRotation ? transform.localRotation.eulerAngles : transform.rotation.eulerAngles,
					to,
					duration,
					easingFunction,
					useLocalRotation));
			return animation;
		}

		/// <summary>
		/// Creates a RotateAnimation that will rotate from the transform's current rotation to the specified rotation
		/// The current rotation will be the transform's rotation when the animation playback commences and not the rotation at the time of the creation of the animation
		/// </summary>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="to">The end rotation (local) of the RotateAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <param name="useLocalRotation">Indicates if the animation will use localRotation</param>
		/// <returns>The newly created RotateAnimation</returns>
		public static DelegateAnimation<RotateAnimation> RotateTo(this Transform transform, Quaternion to, float duration = 1f, Func<float, float> easingFunction = null, bool useLocalRotation = false)
		{
			var animation = new DelegateAnimation<RotateAnimation>(() =>
				new RotateAnimation(
					transform.gameObject,
					useLocalRotation ? transform.localRotation : transform.rotation,
					to,
					duration,
					easingFunction,
					useLocalRotation));
			return animation;
		}

		/// <summary>
		/// Creates a RotateAnimation that will rotate the transform by the offset specified from it's current rotation.
		/// The current rotation will be the transform's rotation when the animation playback commences and not the rotation at the time of the creation of the animation
		/// </summary>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="offset">The offset or delta the animation will move the transform by</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created RotateAnimation</returns>
		public static DelegateAnimation<RotateAnimation> RotateRelative(this Transform transform, Vector3 offset, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<RotateAnimation>(() =>
				new RotateAnimation(
					transform.gameObject,
					transform.localEulerAngles,
					transform.localEulerAngles + offset,
					duration,
					easingFunction));
			return animation;
		}
	}
}
