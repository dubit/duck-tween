using UnityEngine;

namespace DUCK.Tween.Easings
{
	public static partial class Ease
	{
		public static float Parabola(float x)
		{
			var sqrRoot = 2f * x - 1f;
			return 1f - sqrRoot * sqrRoot;
		}

		public static float PingPong(float x)
		{
			return 1f - Mathf.Abs(2f * x - 1f);
		}
	}
}