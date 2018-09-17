using UnityEngine;

namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		public static class PingPong
		{
			private const float PI2 = Mathf.PI * 2f;

			public static float Linear(float x)
			{
				return 1f - Mathf.Abs(2f * x - 1f);
			}

			public static float Parabola(float x)
			{
				var sqrRoot = 2f * x - 1f;
				return 1f - sqrRoot * sqrRoot;
			}

			public static float Sine(float x)
			{
				return (Mathf.Sin(x * PI2) + 1.0f) * 0.5f;
			}
		}
	}
}