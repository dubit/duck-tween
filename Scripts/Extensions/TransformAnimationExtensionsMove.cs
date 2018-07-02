using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	public static partial class TransformAnimationExtensions
	{
		/// <summary>
		/// Creates a new MoveAnimation using this transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="from">The start position of the MoveAnimation</param>
		/// <param name="to">The end position of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created move Animation</returns>
		public static MoveAnimation Move(this Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new MoveAnimation(transform.gameObject, from, to, duration, easingFunction, false);
		}

		/// <summary>
		/// Creates a new MoveAnimation using 2 transforms
		/// </summary>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="from">The transform to use for the start position of the MoveAnimation</param>
		/// <param name="to">The transform to use for the end position of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created move Animation</returns>
		public static DelegateAnimation<MoveAnimation> MoveBetween(this Transform transform, Transform from, Transform to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<MoveAnimation>(() =>
				new MoveAnimation(
					transform.gameObject,
					from.position,
					to.position,
					duration,
					easingFunction,
					false));
			return animation;
		}

		/// <summary>
		/// Creates a new MoveAnimation that uses local position using this transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="from">The start position (local) of the MoveAnimation</param>
		/// <param name="to">The end position (local) of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created move Animation</returns>
		public static MoveAnimation MoveLocal(this Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new MoveAnimation(transform.gameObject, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates MoveAnimation that will move from the transform's current position to the specified position
		/// The current position will be the transform's position when the animation playback commences and not the position at the time of the creation of the animation
		/// </summary>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="to">The end position (local) of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <param name="useLocalPosition">Indicates if the animation will use localPosition</param>
		/// <returns>The newly created move Animation</returns>
		public static DelegateAnimation<MoveAnimation> MoveTo(this Transform transform, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null, bool useLocalPosition = false)
		{
			var animation = new DelegateAnimation<MoveAnimation>(() =>
				new MoveAnimation(
					transform.gameObject,
					useLocalPosition ? transform.localPosition : transform.position,
					to,
					duration,
					easingFunction,
					useLocalPosition));
			return animation;
		}

		/// <summary>
		/// Creates a MoveAnimation that will move the transform by the offset specified from it's current position.
		/// The current position will be the transform's position when the animation playback commences and not the position at the time of the creation of the animation
		/// </summary>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="offset">The offset or delta the animation will move the transform by</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created move Animation</returns>
		public static DelegateAnimation<MoveAnimation> MoveRelative(this Transform transform, Vector3 offset, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<MoveAnimation>(() =>
				new MoveAnimation(
					transform.gameObject,
					transform.localPosition,
					transform.localPosition + offset,
					duration,
					easingFunction));
			return animation;
		}
	}
}
