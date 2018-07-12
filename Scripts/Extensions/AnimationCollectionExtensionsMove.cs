using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	/// <summary>
	/// Animation Sequence Extensions and Helpers
	/// </summary>
	public static partial class AnimationCollectionExtensions
	{
		/// <summary>
		/// Adds a MoveAnimation to the sequence
		/// </summary>
		/// <param name="animationCollection">The target animation sequence</param>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="from">The start position of the MoveAnimation</param>
		/// <param name="to">The end position of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Move(this AnimationCollection animationCollection, Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.Move(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a MoveAnimation to the sequence
		/// </summary>
		/// <param name="animationCollection">The target animation sequence</param>
		/// <param name="rectTransform">The rect transform that will be used in the MoveAnimation</param>
		/// <param name="from">The start position of the MoveAnimation</param>
		/// <param name="to">The end position of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection MoveAnchor(this AnimationCollection animationCollection, RectTransform rectTransform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(rectTransform.MoveAnchor(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a MoveAnimation to the sequence, using local positions
		/// </summary>
		/// <param name="animationCollection">The target animation sequence</param>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="from">The start position (local) of the MoveAnimation</param>
		/// <param name="to">The end position (local) of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection MoveLocal(this AnimationCollection animationCollection, Transform transform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.MoveLocal(from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a MoveAnimation to the sequence that will move from the transform's current position to the specified position
		/// The current position will be the transform's position when the animation playback commences and not the position at the time of the creation of the animation
		/// </summary>
		/// <param name="animationCollection">The target animation sequence</param>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="to">The end position (local) of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <param name="useLocalPosition">Indicates if the animation will use localPosition</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection MoveTo(this AnimationCollection animationCollection, Transform transform, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null, bool useLocalPosition = false)
		{
			return animationCollection.Add(transform.MoveTo(to, duration, easingFunction, useLocalPosition));
		}

		/// <summary>
		/// Adds a MoveAnimation to the sequence that will move from the transform's current position to the specified position
		/// The current position will be the transform's position when the animation playback commences and not the position at the time of the creation of the animation
		/// </summary>
		/// <param name="animationCollection">The target animation sequence</param>
		/// <param name="rectTransform">The rect transform that will be used in the MoveAnimation</param>
		/// <param name="to">The end position (local) of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection MoveAnchorTo(this AnimationCollection animationCollection, RectTransform rectTransform, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(rectTransform.MoveAnchorTo(to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a MoveAnimation to the sequence that will move the transform by the offset specified from it's current position.
		/// The current position will be the transform's position when the animation playback commences and not the position at the time of the creation of the animation 
		/// </summary>
		/// <param name="animationCollection">The target animation sequence</param>
		/// <param name="transform">The transform that will be used in the MoveAnimation</param>
		/// <param name="offset">The offset or delta the animation will move the transform by</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection MoveRelative(this AnimationCollection animationCollection, Transform transform, Vector3 offset, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(transform.MoveRelative(offset, duration, easingFunction));
		}

		/// <summary>
		/// Adds a MoveAnimation to the sequence that will move the transform by the offset specified from it's current position.
		/// The current position will be the transform's position when the animation playback commences and not the position at the time of the creation of the animation
		/// </summary>
		/// <param name="animationCollection">The target animation sequence</param>
		/// <param name="rectTransform">The rect transform that will be used in the MoveAnimation</param>
		/// <param name="offset">The offset or delta the animation will move the transform by</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection MoveAnchorRelative(this AnimationCollection animationCollection, RectTransform rectTransform, Vector3 offset, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(rectTransform.MoveAnchorRelative(offset, duration, easingFunction));
		}
	}
}
