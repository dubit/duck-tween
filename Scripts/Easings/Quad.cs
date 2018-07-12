namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Quad easing functions
		/// Ported from Haxe to C#
		/// Source code: https://github.com/openfl/actuate/blob/master/motion/easing/Quad.hx
		/// </summary>
		public static class Quad
		{
			public static float In(float k)
			{
				return k * k;
			}

			public static float Out(float k)
			{
				return -k * (k - 2.0f);
			}

			public static float InOut(float k)
			{
				if ((k *= 2.0f) < 1.0f)
				{
					return 0.5f * k * k;
				}

				return -0.5f * ((k - 1.0f) * (k - 3.0f) - 1.0f);
			}
		}
	}
}
