namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Cubic easing functions
		/// Ported from Haxe to C#
		/// Source code: https://github.com/openfl/actuate/blob/master/motion/easing/Cubic.hx
		/// </summary>
		public static class Cubic
		{
			public static float In(float k)
			{
				return k * k * k;
			}

			public static float Out(float k)
			{
				return --k * k * k + 1.0f;
			}

			public static float InOut(float k)
			{
				return (k /= 1.0f / 2.0f) < 1.0f ? 0.5f * k * k * k : 0.5f * ((k -= 2.0f) * k * k + 2.0f);
			}
		}
	}
}
