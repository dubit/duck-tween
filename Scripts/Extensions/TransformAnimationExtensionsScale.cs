using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	public static partial class TransformAnimationExtensions
	{
		/// <summary>
		/// Creates a new ScaleAnimation using this transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The new created ScaleAnimation</returns>
		public static ScaleAnimation Scale(this Transform transform, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new ScaleAnimation(transform.gameObject, Vector3.one * from, Vector3.one * to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a new ScaleAnimation using this transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The new created ScaleAnimation</returns>
		public static ScaleAnimation Scale(this Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new ScaleAnimation(transform.gameObject, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates a ScaleAnimation that will scale to the given target scale, starting at the transform's current scale
		/// The current scale will be the transform's position when the animation playback commences and not the scale at the time of the creation of the animation 
		/// </summary>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The new created ScaleAnimation</returns>
		public static DelegateAnimation<ScaleAnimation> ScaleTo(this Transform transform, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<ScaleAnimation>(() =>
				new ScaleAnimation(transform.gameObject, transform.localScale, to, duration, easingFunction));
			return animation;
		}

		/// <summary>
		/// Creates a ScaleAnimation that will scale to the given target scale, starting at the transform's current scale
		/// The current scale will be the transform's position when the animation playback commences and not the scale at the time of the creation of the animation 
		/// </summary>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The new created ScaleAnimation</returns>
		public static DelegateAnimation<ScaleAnimation> ScaleTo(this Transform transform, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<ScaleAnimation>(() =>
				new ScaleAnimation(transform.gameObject, transform.localScale, Vector3.one * to, duration, easingFunction));
			return animation;
		}

		/// <summary>
		/// Creates a ScaleAnimation to the sequence that scales the X component of the transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created ScaleAnimation</returns>
		public static ScaleAnimation ScaleX(this Transform transform, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var currentScale = transform.localScale;
			currentScale.x = from;
			var targetScale = currentScale;
			targetScale.x = to;
			return new ScaleAnimation(transform.gameObject, currentScale, targetScale, duration, easingFunction);
		}


		/// <summary>
		/// Creates a ScaleAnimation to the sequence that scales the Y component of the transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created ScaleAnimation</returns>
		public static ScaleAnimation ScaleY(this Transform transform, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var currentScale = transform.localScale;
			currentScale.y = from;
			var targetScale = currentScale;
			targetScale.y = to;
			return new ScaleAnimation(transform.gameObject, currentScale, targetScale, duration, easingFunction);
		}

		/// <summary>
		/// Creates a ScaleAnimation to the sequence that scales the Z component of the transform
		/// </summary>
		/// <param name="transform">The transform that will be used in the ScaleAnimation</param>
		/// <param name="from">The start scale of the ScaleAnimation</param>
		/// <param name="to">The end scale of the ScaleAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created ScaleAnimation</returns>
		public static ScaleAnimation ScaleZ(this Transform transform, float from, float to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var currentScale = transform.localScale;
			currentScale.z = from;
			var targetScale = currentScale;
			targetScale.z = to;
			return new ScaleAnimation(transform.gameObject, currentScale, targetScale, duration, easingFunction);
		}
	}
}
