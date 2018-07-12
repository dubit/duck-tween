namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Back easing functions
		/// Ported from Haxe to C#
		/// Source code: https://github.com/openfl/actuate/blob/master/motion/easing/Back.hx
		/// </summary>
		public static class Back
		{
			private const float FANCY_VALUE = 1.70158f;
			private const float FANCY_IN_OUT_VALUE = 1.525f;

			public static float In(float k)
			{
				return k * k * ((FANCY_VALUE + 1.0f) * k - FANCY_VALUE);
			}

			public static float Out(float k)
			{
				return (k = k - 1.0f) * k * ((FANCY_VALUE + 1.0f) * k + FANCY_VALUE) + 1.0f;
			}

			public static float InOut(float k)
			{
				var s = FANCY_IN_OUT_VALUE;

				if ((k /= 0.5f) < 1.0f)
				{
					return 0.5f * (k * k * (((s *= FANCY_IN_OUT_VALUE) + 1.0f) * k - s));
				}

				return 0.5f * ((k -= 2.0f) * k * (((s *= FANCY_IN_OUT_VALUE) + 1.0f) * k + s) + 2.0f);
			}
		}
	}
}
