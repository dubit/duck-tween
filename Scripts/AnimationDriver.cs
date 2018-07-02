using System;
using DUCK.Utils;
using UnityEngine;

namespace DUCK.Tween
{
	/// <summary>
	/// Animation Driver should maintain a list of update
	/// </summary>
	public interface IAnimationDriver
	{
		/// <summary>
		/// Add the Update Function into the update list.
		/// </summary>
		/// <param name="updateFunction">The target Update Function</param>
		void Add(Action<float> updateFunction);

		/// <summary>
		/// Remove the Update Function from the update list.
		/// </summary>
		/// <param name="updateFunction">The target Update Function</param>
		void Remove(Action<float> updateFunction);
	}

	public class DefaultAnimationDriver : MonoBehaviour, IAnimationDriver
	{
		public static DefaultAnimationDriver Instance { get { return instance == null ? CreateInstance() : instance; } }
		private static DefaultAnimationDriver instance;

		private static readonly UpdateList updateList = new UpdateList();

		private static DefaultAnimationDriver CreateInstance()
		{
			var gameObject = new GameObject { hideFlags = HideFlags.HideInHierarchy };
			//NOTE When running tests you cannot use DontDestroyOnLoad in editor mode
			if (Application.isPlaying)
			{
				DontDestroyOnLoad(gameObject);
			}
			return instance = gameObject.AddComponent<DefaultAnimationDriver>();
		}

		public void Add(Action<float> updateFunction)
		{
			updateList.Add(updateFunction);
		}

		public void Remove(Action<float> updateFunction)
		{
			updateList.Remove(updateFunction);
		}

		private void Update()
		{
			updateList.Update(Time.unscaledDeltaTime);
		}
	}
}