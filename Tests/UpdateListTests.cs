using System;
using DUCK.Utils;
using NUnit.Framework;

namespace DUCK.Utils.Editor
{
	[TestFixture]
	public class UpdateListTest
	{
		[Test]
		public void ExpectConstructorNotToThrow()
		{
			Assert.DoesNotThrow(() =>
			{
				new UpdateList();
			});
		}

		[Test]
		public void ExpectAddedFunctionToBeCalledWhenUpdated()
		{
			var wasCalled = false;
			Action<float> func = dt =>
			{
				wasCalled = true;
			};

			var updateList = new UpdateList();
			updateList.Add(func);
			Assert.IsFalse(wasCalled);
			updateList.Update(0f);
			Assert.IsTrue(wasCalled);
		}

		[Test]
		public void ExpectAddToThrowIfFunctionIsAlreadyAdded()
		{
			Action<float> func = dt => {};
			var updateList = new UpdateList();
			updateList.Add(func);
			Assert.Throws<Exception>(() =>
			{
				updateList.Add(func);
			});
		}

		[Test]
		public void ExpectContainsToReturnTrueOnlyIfFunctionWasAdded()
		{
			Action<float> func = dt => {};
			var updateList = new UpdateList();
			Assert.IsFalse(updateList.Contains(func));
			updateList.Add(func);
			Assert.IsTrue(updateList.Contains(func));
		}

		[Test]
		public void ExpectRemoveToThrowIfFunctionWasNotFound()
		{
			Action<float> func = dt => {};
			var updateList = new UpdateList();

			Assert.Throws<Exception>(() =>
			{
				updateList.Remove(func);
			});
		}

		[Test]
		public void ExpectFunctionToNotBeCalledIfRemoveWasCalled()
		{
			var wasCalled = false;
			Action<float> func = dt =>
			{
				wasCalled = true;
			};

			var updateList = new UpdateList();
			updateList.Add(func);
			Assert.IsFalse(wasCalled);
			updateList.Remove(func);
			Assert.IsFalse(wasCalled);

			updateList.Update(0f);
			Assert.IsFalse(wasCalled);
		}

		[Test]
		public void ExpectContainsToReturnFalseAfterRemoveWasCalled()
		{
			Action<float> func = dt => { };
			var updateList = new UpdateList();
			updateList.Add(func);
			updateList.Remove(func);
			Assert.IsFalse(updateList.Contains(func));
		}

		[Test]
		public void ExpectContainsToReturnFalseAfterRemoveWasCalledDuringFrame()
		{
			// we have to create another ref to the function so we can self remove within closure
			Action<float> funcRef = null;

			var updateList = new UpdateList();

			Action<float> func = dt =>
			{
				updateList.Remove(funcRef);

				Assert.IsFalse(updateList.Contains(funcRef));
			};

			funcRef = func;

			updateList.Add(funcRef);

			updateList.Update(0f);
		}

		[Test]
		public void ExpectRemoveAndReAddWithinAnUpdateLoopToNotRemove()
		{
			var updateList = new UpdateList();

			Action<float> func2 = dt => { };
			Action<float> func1 = dt =>
			{
				updateList.Remove(func2);
				updateList.Add(func2);
			};

			updateList.Add(func1);
			updateList.Add(func2);

			updateList.Update(0f);

			Assert.IsTrue(updateList.Contains(func2));
		}

		[Test]
		public void ExpectUpdateToPassDeltaTimeToAllFunctions()
		{
			const float dtParam = 0.112f;

			Action<float> func = dt =>
			{
				Assert.AreEqual(dt, dtParam);
			};

			var updateList = new UpdateList();
			updateList.Add(func);
			updateList.Update(dtParam);
		}

		[Test]
		public void TestPreviousKnownBreakingEdgecases()
		{
			var updateList = new UpdateList();

			// we have to create another ref to the functions so we can self remove within closures
			Action<float> func2 = null;
			Action<float> func0 = null;

			Action<float> update2 = dt =>
			{
				// Do nothing special
			};

			Action<float> update1 = dt =>
			{
				updateList.Remove(func2);
			};

			Action<float> update0 = dt =>
			{
				updateList.Remove(func0);
			};

			func2 = update2;
			func0 = update0;

			updateList.Add(update0);
			updateList.Add(update1);
			updateList.Add(update2);

			updateList.Update(0f);

			Assert.IsFalse(updateList.Contains(update0));
			Assert.IsTrue(updateList.Contains(update1));
			Assert.IsFalse(updateList.Contains(update2));

			// now dead test that index 2 is not marked as dead. by adding new updates, running them and checking they still exist
			updateList.Remove(update1);

			Action<float> update3Index0 = dt => { };
			Action<float> update4Index1 = dt => { };
			Action<float> update5Index2 = dt => { };


			updateList.Add(update3Index0);
			updateList.Add(update4Index1);
			updateList.Add(update5Index2);

			updateList.Update(0f);

			Assert.IsTrue(updateList.Contains(update3Index0));
			Assert.IsTrue(updateList.Contains(update4Index1));
			Assert.IsTrue(updateList.Contains(update5Index2));
		}
	}
}