using System;
using System.Collections.Generic;

namespace DUCK.Tween.Easings
{
	public class EasingFunctionStore
	{
		public static Dictionary<string, Func<float, float>> EasingFunctions { get; private set; }
		static EasingFunctionStore()
		{
			// Reflection could get all these but the invoke would be a lot slower at runtime
			// Instead we just grab direct function references
			EasingFunctions = new Dictionary<string, Func<float, float>>
			{
				{"Linear", Ease.Linear.None},
				{"Back.In", Ease.Back.In},
				{"Back.Out", Ease.Back.Out},
				{"Back.InOut", Ease.Back.InOut},
				{"Bounce.In", Ease.Bounce.In},
				{"Bounce.Out", Ease.Bounce.Out},
				{"Bounce.InOut", Ease.Bounce.InOut},
				{"Circ.In", Ease.Circ.In},
				{"Circ.Out", Ease.Circ.Out},
				{"Circ.InOut", Ease.Circ.InOut},
				{"Cubic.In", Ease.Cubic.In},
				{"Cubic.Out", Ease.Cubic.Out},
				{"Cubic.InOut", Ease.Cubic.InOut},
				{"Elastic.In", Ease.Elastic.In},
				{"Elastic.Out", Ease.Elastic.Out},
				{"Elastic.InOut", Ease.Elastic.InOut},
				{"Expo.In", Ease.Expo.In},
				{"Expo.Out", Ease.Expo.Out},
				{"Expo.InOut", Ease.Expo.InOut},
				{"Quad.In", Ease.Quad.In},
				{"Quad.Out", Ease.Quad.Out},
				{"Quad.InOut", Ease.Quad.InOut},
				{"Quart.In", Ease.Quart.In},
				{"Quart.Out", Ease.Quart.Out},
				{"Quart.InOut", Ease.Quart.InOut},
				{"Quint.In", Ease.Quint.In},
				{"Quint.Out", Ease.Quint.Out},
				{"Quint.InOut", Ease.Quint.InOut},
				{"Sine.In", Ease.Sine.In},
				{"Sine.Out", Ease.Sine.Out},
				{"Sine.InOut", Ease.Sine.InOut},
				{"Parabola", Ease.Parabola}
			};
		}
	}
}