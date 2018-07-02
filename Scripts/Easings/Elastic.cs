using UnityEngine;

namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Elastic easing functions
		/// Ported from Haxe to C#
		/// Source code: https://github.com/openfl/actuate/blob/master/motion/easing/Elastic.hx
		/// </summary>
		public static class Elastic
		{
			private const float PI_2 = Mathf.PI * 2.0f;
			private const float POW_2_10 = 6.931471805599453f;

			public static float In(float k)
			{
				if (k <= 0) return 0;

				if (k >= 1.0f) return 1.0f;

				const float p = 0.4f;
				const float s = p / 4.0f;

				return -(Mathf.Exp(POW_2_10 * (k -= 1.0f)) * Mathf.Sin((k - s) * PI_2 / p));
			}

			public static float Out(float k)
			{
				if (k <= 0) return 0;

				if (k >= 1.0f) return 1.0f;

				const float p = 0.4f;
				const float s = p / 4.0f;

				return Mathf.Exp(-POW_2_10 * k) * Mathf.Sin((k - s) * PI_2 / p) + 1.0f;
			}

			public static float InOut(float k)
			{
				if (k <= 0) return 0;

				if ((k /= 0.5f) >= 2.0f) return 1.0f;

				const float p = 0.3f * 1.5f;
				const float s = p / 4.0f;

				if (k < 1.0f)
				{
					return -0.5f * (Mathf.Exp(POW_2_10 * (k -= 1.0f)) * Mathf.Sin((k - s) * PI_2 / p));
				}

				return Mathf.Exp(-POW_2_10 * (k -= 1.0f)) * Mathf.Sin((k - s) * PI_2 / p) * 0.5f + 1.0f;
			}
		}
	}
}
