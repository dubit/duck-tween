namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		/// <summary>
		/// Quart easing functions
		/// Ported from Haxe to C#
		/// Source code: https://github.com/openfl/actuate/blob/master/motion/easing/Quart.hx
		/// </summary>
		public static class Quart
		{
			public static float In(float k)
			{
				return k * k * k * k;
			}

			public static float Out(float k)
			{
				return -(--k * k * k * k - 1.0f);
			}

			public static float InOut(float k)
			{
				if ((k *= 2.0f) < 1.0f)
				{
					return 0.5f * k * k * k * k;
				}

				return -0.5f * ((k -= 2.0f) * k * k * k - 2.0f);
			}
		}
	}
}
