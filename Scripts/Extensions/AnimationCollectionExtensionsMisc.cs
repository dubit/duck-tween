using System;
using UnityEngine;

namespace DUCK.Tween.Extensions
{
	/// <summary>
	/// Animation Collection Extensions and Helpers
	/// </summary>
	public static partial class AnimationCollectionExtensions
	{
		/// <summary>
		/// Adds a WaitAnimation to the collection that will wait for the specified amount of seconds
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="duration">The duration of the animation in seconds, defaults to 1f</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Wait(this AnimationCollection animationCollection, float duration)
		{
			return animationCollection.Add(new WaitAnimation(duration));
		}

		/// <summary>
		/// Adds a FunctionCallAnimation to the collection
		/// This will invoke the function when this animation is played
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="action">The action to be invoked</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Invoke(this AnimationCollection animationCollection, Action action)
		{
			return animationCollection.Add(new FunctionCallAnimation(action));
		}

		/// <summary>
		/// Adds an animation to the collection that activates (or deactivates) a GameObject
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="gameObject">The GameObject to activate or deactivate</param>
		/// <param name="value">A boolean value indicating the desired active state of the game object after this animation</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Activate(this AnimationCollection animationCollection, GameObject gameObject, bool value)
		{
			return animationCollection.Add(new FunctionCallAnimation(() => gameObject.SetActive(value)));
		}

		/// <summary>
		/// Adds an animation to the collection that enables (or disables) a Behaviour
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="behaviour">The Behaviour to enable or disable</param>
		/// <param name="value">A boolean value indicating the desired enabled state of the behaviour after this animation</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Enable(this AnimationCollection animationCollection, Behaviour behaviour, bool value)
		{
			return animationCollection.Add(new FunctionCallAnimation(() => behaviour.enabled = value));
		}

		/// <summary>
		/// Adds a SequencedAnimation as a child of this AnimationCollection,
		/// using the specified callback to configure the collection
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="configureFunction"></param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Sequence(this AnimationCollection animationCollection, Action<SequencedAnimation> configureFunction)
		{
			var sequence = new SequencedAnimation();
			animationCollection.Add(sequence);
			configureFunction(sequence);
			return animationCollection;
		}

		/// <summary>
		/// Adds a ParalleledAnimation as a child of this AnimationCollection,
		/// using the specified callback to configure the collection
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="configureFunction"></param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Parallel(this AnimationCollection animationCollection, Action<ParalleledAnimation> configureFunction)
		{
			var parallel = new ParalleledAnimation();
			animationCollection.Add(parallel);
			configureFunction(parallel);
			return animationCollection;
		}

		/// <summary>
		/// Adds a CustomAnimation as a child of this AnimationCollection
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="customUpdate">A Custom Update function</param>
		/// <param name="from">From value</param>
		/// <param name="to">To value</param>
		/// <param name="duration">Duration of the animation</param>
		/// <param name="easingFunction">The easing function for the interpolation</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Custom(this AnimationCollection animationCollection, Action<float> customUpdate,
			float from = 0, float to = 1.0f, float duration = 1.0f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(new CustomAnimation(customUpdate, from, to, duration, easingFunction));
		}

		/// <summary>
		/// Adds a CustomAnimation as a child of this AnimationCollection
		/// </summary>
		/// <param name="animationCollection">The target animation collection</param>
		/// <param name="target">The target object</param>
		/// <param name="customUpdate">A Custom Update function</param>
		/// <param name="from">From value</param>
		/// <param name="to">To value</param>
		/// <param name="duration">Duration of the animation</param>
		/// <param name="easingFunction">The easing function for the interpolation</param>
		/// <returns>Returns this AnimationCollection to comply with fluent interface</returns>
		public static AnimationCollection Custom<T>(this AnimationCollection animationCollection, T target, Action<T, float> customUpdate,
			float from = 0, float to = 1.0f, float duration = 1.0f, Func<float, float> easingFunction = null)
		{
			return animationCollection.Add(new CustomAnimation<T>(target, customUpdate, from, to, duration, easingFunction));
		}
	}
}
