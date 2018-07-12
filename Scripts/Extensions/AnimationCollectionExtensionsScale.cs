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
		/// Adds a ScaleAnimation to the collection
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Scale(this AnimationCollection animationCollection, Transform transform, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.Scale(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a ScaleAnimation to the collection
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Scale(this AnimationCollection animationCollection, Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.Scale(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a ScaleAnimation to the collection that will scale to the given target scale, starting at the transform's current scale
		/// The current scale will be the transform's position when the animation playback commences and not the scale at the time of the creation of the animation
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection ScaleTo(this AnimationCollection animationCollection, Transform transform, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.ScaleTo(to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a ScaleAnimation to the collection that will scale to the given target scale, starting at the transform's current scale
		/// The current scale will be the transform's position when the animation playback commences and not the scale at the time of the creation of the animation
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection ScaleTo(this AnimationCollection animationCollection, Transform transform, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.ScaleTo(to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a ScaleAnimation to the collection that scales the X component of the transform
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection ScaleX(this AnimationCollection animationCollection, Transform transform, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.ScaleX(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a ScaleAnimation to the collection that scales the Y component of the transform
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection ScaleY(this AnimationCollection animationCollection, Transform transform, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.ScaleY(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a ScaleAnimation to the collection that scales the Z component of the transform
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection ScaleZ(this AnimationCollection animationCollection, Transform transform, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.ScaleZ(from, to, duration, easingFunction));
		}
	}
}
