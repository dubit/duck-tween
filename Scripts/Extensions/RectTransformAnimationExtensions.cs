using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	public static class RectTransformAnimationExtensions
	{
		/// <summary>
		/// Creates a new MoveAnimation using this rect transform
		/// </summary>
		/// <param name="rectTransform">The rect transform that will be used in the MoveAnimation</param>
		/// <param name="from">The start position of the MoveAnimation</param>
		/// <param name="to">The end position of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created move Animation</returns>
		public static MoveAnimation MoveAnchor(this RectTransform rectTransform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			return new MoveAnimation(rectTransform, from, to, duration, easingFunction);
		}

		/// <summary>
		/// Creates MoveAnimation that will move from the rect transform anchor's current position to the specified position
		/// The current position will be the transform's position when the animation playback commences and not the position at the time of the creation of the animation
		/// </summary>
		/// <param name="rectTransform">The rect transform that will be used in the MoveAnimation</param>
		/// <param name="to">The end position (local) of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created move Animation</returns>
		public static DelegateAnimation<MoveAnimation> MoveAnchorTo(this RectTransform rectTransform, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<MoveAnimation>(() =>
				new MoveAnimation(
					rectTransform,
					rectTransform.anchoredPosition3D,
					to,
					duration,
					easingFunction));
			return animation;
		}

		/// <summary>
		/// Creates a MoveAnimation that will move the anchor position of the rect transform by the offset specified from it's current position.
		/// The current position will be the transform's position when the animation playback commences and not the position at the time of the creation of the animation
		/// </summary>
		/// <param name="rectTransform">The rect transform that will be used in the MoveAnimation</param>
		/// <param name="offset">The offset or delta the animation will move the transform by</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <returns>The newly created move Animation</returns>
		public static DelegateAnimation<MoveAnimation> MoveAnchorRelative(this RectTransform rectTransform, Vector3 offset, float duration = 1f, Func<float, float> easingFunction = null)
		{
			var animation = new DelegateAnimation<MoveAnimation>(() =>
				new MoveAnimation(
					rectTransform,
					rectTransform.anchoredPosition3D,
					rectTransform.anchoredPosition3D + offset,
					duration,
					easingFunction));
			return animation;
		}
	}
}