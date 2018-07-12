using UnityEngine;

namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Sine easing functions
		/// Ported from Haxe to C#
		/// Source code: https://github.com/openfl/actuate/blob/master/motion/easing/Sine.hx
		/// </summary>
		public static class Sine
		{
			private const float HALF_PI = Mathf.PI * 0.5f;

			public static float In(float k)
			{
				return 1.0f - Mathf.Cos(k * HALF_PI);
			}

			public static float Out(float k)
			{
				return Mathf.Sin(k * HALF_PI);
			}

			public static float InOut(float k)
			{
				return -(Mathf.Cos(Mathf.PI * k) - 1.0f) / 2.0f;
			}
		}
	}
}
