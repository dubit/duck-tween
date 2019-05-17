using System;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// Blend Shape Animation will blend your shapes!
	/// </summary>
	public class BlendShapeAnimation : AbstractFloatAnimation
	{
		public override bool IsValid => skinnedMeshRenderer != null && blendShapeIndex >= 0;

		private readonly Action<float> customUpdate;
		private readonly SkinnedMeshRenderer skinnedMeshRenderer;
		private readonly int blendShapeIndex;

		/// <summary>
		/// Create a new Blend Shape Animation.
		/// </summary>
		/// <param name="skinnedMeshRenderer">Target SkinnedMeshRenderer</param>
		/// <param name="blendShapeIndex">The Blend Shape Index</param>
		/// <param name="from">From value</param>
		/// <param name="to">To value</param>
		/// <param name="duration">Duration of the animation</param>
		/// <param name="easingFunction">The easing function for the interpolation</param>
		public BlendShapeAnimation(SkinnedMeshRenderer skinnedMeshRenderer, int blendShapeIndex, float from = 0, float to = 100f, float duration = 1.0f, Func<float, float> easingFunction = null)
			: base(skinnedMeshRenderer.gameObject, from, to, duration, easingFunction)
		{
			this.skinnedMeshRenderer = skinnedMeshRenderer;
			this.blendShapeIndex = blendShapeIndex;
		}

		protected override void SetValue(float alpha)
		{
			skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, alpha);
		}
	}
}