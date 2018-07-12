namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Bounce easing functions
		/// Ported from Haxe to C#
		/// Source code: https://github.com/openfl/actuate/blob/master/motion/easing/Bounce.hx
		/// </summary>
		public static class Bounce
		{
			public static float In(float k)
			{
				return 1.0f - EaseOut(1.0f - k);
			}

			public static float Out(float k)
			{
				return EaseOut(k);
			}

			public static float InOut(float k)
			{
				return k < 0.5f ? In(k * 2.0f) * 0.5f : Out(k * 2.0f - 1.0f) * 0.5f + 0.5f;
			}

			private static float EaseOut(float t)
			{
				const float bounce = 7.5625f;
				const float t1 = 1.0f / 2.75f;
				const float t15 = 1.5f / 2.75f;
				const float t2 = 2.0f / 2.75f;
				const float t225 = 2.25f / 2.75f;
				const float t25 = 2.5f / 2.75f;
				const float t2625 = 2.625f / 2.75f;

				if ((t /= 1.0f) < t1)
				{
					return bounce * t * t;
				}

				if (t < t2)
				{
					return bounce * (t -= t15) * t + 0.75f;
				}

				if (t < t25)
				{
					return bounce * (t -= t225) * t + 0.9375f;
				}

				return bounce * (t -= t2625) * t + 0.984375f;
			}
		}
	}
}
