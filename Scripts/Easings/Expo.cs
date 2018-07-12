using UnityEngine;

namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Expo easing functions
		/// Ported from Haxe to C#
		/// Source code: https://github.com/openfl/actuate/blob/master/motion/easing/Expo.hx
		/// </summary>
		public static class Expo
		{
			private const float POW_2_10 = 6.931471805599453f;

			public static float In(float k)
			{
				return k <= 0 ? 0 : Mathf.Exp(POW_2_10 * (k - 1.0f));
			}

			public static float Out(float k)
			{
				return k >= 1.0f ? 1.0f : (1.0f - Mathf.Exp(-POW_2_10 * k));
			}

			public static float InOut(float k)
			{
				if (k <= 0) return 0;

				if (k >= 1.0f) return 1.0f;

				if ((k /= 0.5f) < 1.0f)
				{
					return 0.5f * Mathf.Exp(POW_2_10 * (k - 1.0f));
				}

				return 0.5f * (2.0f - Mathf.Exp(-POW_2_10 * --k));
			}
		}
	}
}
