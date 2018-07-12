using UnityEngine;

namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Circ easing functions
		/// Ported from JavaScript to C#
		/// Source code: https://github.com/ai/easings.net/blob/master/vendor/jquery.easing.js#L109
		/// </summary>
		public static class Circ
		{
			public static float In(float k)
			{
				return -(Mathf.Sqrt(1.0f - (k * k)) - 1.0f);
			}

			public static float Out(float k)
			{
				return Mathf.Sqrt(1.0f - (k -= 1.0f) * k);
			}

			public static float InOut(float k)
			{
				if ((k /= 0.5f) < 1.0f)
				{
					return 0.5f * In(k);
				}

				return 0.5f * (Mathf.Sqrt(1.0f - (k -= 2.0f) * k) + 1.0f);
			}
		}
	}
}
