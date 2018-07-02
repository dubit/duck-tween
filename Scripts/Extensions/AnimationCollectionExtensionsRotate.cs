using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	/// <summary>
	/// Animation Collection Extensions and Helpers
	/// </summary>
	public static partial class AnimationCollectionExtensions
	{
		/// <summary>
		/// Adds a RotateAnimation to the collection
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="from">The start rotation of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="to">The end rotation of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Rotate(this AnimationCollection animationCollection, Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.Rotate(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a RotateAnimation to the collection
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="from">The start rotation of the RotateAnimation</param>
		/// <param name="to">The end rotation of the RotateAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Rotate(this AnimationCollection animationCollection, Transform transform, Quaternion from, Quaternion to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.Rotate(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a RotateAnimation to the collection, using local rotation
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="from">The start rotation (local) of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="to">The end rotation (local) of the RotateAnimation expressed as eulerAngles</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection RotateLocal(this AnimationCollection animationCollection, Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.RotateLocal(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a RotateAnimation to the collection, using local rotation
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="from">The start rotation (local) of the RotateAnimation</param>
		/// <param name="to">The end rotation (local) of the RotateAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection RotateLocal(this AnimationCollection animationCollection, Transform transform, Quaternion from, Quaternion to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.RotateLocal(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a RotateAnimation to the collection that will rotate from the transform's current rotation to the specified rotation
		/// The current rotation will be the transform's rotation when the animation playback commences and not the rotation at the time of the creation of the animation
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="to">The end rotation (local) of the RotateAnimation, expressed in eulerAngles</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <param name="useLocalRotation">Indicates if the animation will use localRotation</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection RotateTo(this AnimationCollection animationCollection, Transform transform, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null, bool useLocalRotation = false)
		{
			return animationCollection.Add(transform.RotateTo(to, duration, easingFunction, useLocalRotation));
		}

		/// <summary>
		/// Adds a RotateAnimation to the collection that will rotate from the transform's current rotation to the specified rotation
		/// The current rotation will be the transform's rotation when the animation playback commences and not the rotation at the time of the creation of the animation
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the RotateAnimation</param>
		/// <param name="to">The end rotation (local) of the RotateAnimation, expressed in eulerAngles</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <param name="useLocalRotation">Indicates if the animation will use localRotation</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection RotateTo(this AnimationCollection animationCollection, Transform transform, Quaternion to, float duration = 1f, Func<float, float> easingFunction = null, bool useLocalRotation = false)
		{
			return animationCollection.Add(transform.RotateTo(to, duration, easingFunction, useLocalRotation));
		}

		/// <summary>
		/// Adds a RotateAnimation to the collection that will rotate the transform by the offset specified from it's current rotation.
		/// The current rotation will be the transform's rotation when the animation playback commences and not the rotation at the time of the creation of the animation
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="offset">The offset or delta the animation will move the transform by</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection RotateRelative(this AnimationCollection animationCollection, Transform transform, Vector3 offset, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.RotateRelative(offset, duration, easingFunction));
		}
	}
}
