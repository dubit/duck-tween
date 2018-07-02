using System;
using System.Collections.Generic;

namespace DUCK.Utils
{
	/// <summary>
	/// UpdateList: allows you to add multiple update functions to a list, then just update the list and all functions
	/// will be called. It also allows removing an update function from the list during the update iteration.
	/// It is very well optimized and is a way to get around multiple monobehaviours. It also allows you to make
	/// multiple instances, to update different objects with different time scales.
	/// </summary>
	public class UpdateList
	{
		private readonly List<Action<float>> updateFunctions = new List<Action<float>>();
		private readonly List<int> deadFunctionIndices = new List<int>();

		private bool isUpdating;

		/// <summary>
		/// Returns true if the update list contains this function
		/// </summary>
		/// <param name="updateFunction">The update function to test for the presence of</param>
		/// <returns>True if the function is in the update list, false if not</returns>
		public bool Contains(Action<float> updateFunction)
		{
			var index = updateFunctions.IndexOf(updateFunction);
			return index != -1 && !deadFunctionIndices.Contains(index);
		}

		/// <summary>
		/// Adds the given function to the update list. It must not already be added.
		/// </summary>
		/// <param name="updateFunction">The update function to add to the update list</param>
		/// <exception cref="Exception">Throws an Exception if the function was already added</exception>
		public void Add(Action<float> updateFunction)
		{
			var index = updateFunctions.IndexOf(updateFunction);
			if (index >= 0)
			{
				// if the function exists but it's marked as dead we should, unmark it (to re add it)
				if (deadFunctionIndices.Contains(index))
				{
					deadFunctionIndices.Remove(index);
					return;
				}

				throw new Exception("Cannot add the given function. It is already in the list");
			}

			updateFunctions.Add(updateFunction);
		}

		/// <summary>
		/// Removes the given update function from the update list
		/// </summary>
		/// <param name="updateFunction">The update function to remove from the list</param>
		/// <exception cref="Exception">Throws if the given update function was not in the list</exception>
		public void Remove(Action<float> updateFunction)
		{
			var index = updateFunctions.IndexOf(updateFunction);
			if (index < 0)
			{
				throw new Exception("Cannot remove the given function. It was not found in the list");
			}

			// if we are currently updating we mark it as dead,
			// otherwise (else) we can remove it straight away
			if (isUpdating)
			{
				if (!deadFunctionIndices.Contains(index))
				{
					deadFunctionIndices.Add(index);
				}
			}
			else
			{
				updateFunctions.RemoveAt(index);
			}
		}

		/// <summary>
		/// Updtes all functions in the list in descending order.
		/// </summary>
		/// <param name="dt">The amount of delta time to be passed into each function.</param>
		public void Update(float dt)
		{
			isUpdating = true;
			for (var i = updateFunctions.Count - 1; i >= 0; --i)
			{
				if (!deadFunctionIndices.Contains(i))
				{
					updateFunctions[i](dt);
				}
			}
			isUpdating = false;

			if (deadFunctionIndices.Count > 0)
			{
				for (var i = updateFunctions.Count - 1; i >= 0; --i)
				{
					if (deadFunctionIndices.Remove(i))
					{
						updateFunctions.RemoveAt(i);
					}
				}
			}
		}
	}
}