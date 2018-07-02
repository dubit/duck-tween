using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// A MoveAnimation is used to move a GameObject from one location to another
	/// </summary>
	public class MoveAnimation : TimedAnimation
	{
		private readonly Vector3 from;
		private readonly Vector3 to;
		private readonly bool willUseLocalPosition;

		/// <summary>
		/// Creates a new MoveAnimation
		/// </summary>
		/// <param name="targetObject">The target GameObject of the animation</param>
		/// <param name="from">The start position of the MoveAnimation</param>
		/// <param name="to">The end position of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		/// <param name="useLocalPosition">Indicates if the animation will use localPosition</param>
		public MoveAnimation(GameObject targetObject, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null, bool useLocalPosition = true)
			: base(targetObject, duration, easingFunction)
		{
			this.from = from;
			this.to = to;
			willUseLocalPosition = useLocalPosition;
		}

		/// <summary>
		/// Creates a new MoveAnimation
		/// </summary>
		/// <param name="rectTransform">The target RectTransform of the animation</param>
		/// <param name="from">The start position of the MoveAnimation</param>
		/// <param name="to">The end position of the MoveAnimation</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <param name="easingFunction">The easing function that will be used to interpolate with</param>
		public MoveAnimation(RectTransform rectTransform, Vector3 from, Vector3 to, float duration = 1f, Func<float, float> easingFunction = null)
			: base(rectTransform, duration, easingFunction)
		{
			this.from = from;
			this.to = to;
		}

		protected override void Refresh(float progress)
		{
			var position = Interpolate(from, to, progress);
			if (TargetRectTransform != null)
			{
				TargetRectTransform.anchoredPosition3D = position;
			}
			else if (willUseLocalPosition)
			{
				TargetObject.transform.localPosition = position;
			}
			else
			{
				TargetObject.transform.position = position;
			}
		}
	}
}