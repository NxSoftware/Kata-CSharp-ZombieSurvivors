using ZombieSurvivors;
using NUnit.Framework;

namespace ZombieSurvivorsTests
{
	public class SurvivorEquipmentTests
	{
		[Test]
		public void SurvivorCanCarryUp2ToPiecesOfEquipmentInHand()
		{
			var s = new Survivor("Steve");
			Assert.IsTrue(s.PutInHand(new DummyEquipment()));
			Assert.IsTrue(s.PutInHand(new DummyEquipment()));
			Assert.IsFalse(s.PutInHand(new DummyEquipment()));
		}

		[Test]
		public void SurvivorCanCarryUpTo5PiecesOfEquipmentInReserve()
		{
			var s = new Survivor("Steve");
			Assert.IsTrue(s.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s.PutInReserve(new DummyEquipment()));
			Assert.IsFalse(s.PutInReserve(new DummyEquipment()));
		}

		[Test]
		public void SurvivorCanCarryUpTo5PiecesOfEquipmentInTotal()
		{
			AssertMaximumCarryingCapacity(inHand: 0, inReserve: 5);
			AssertMaximumCarryingCapacity(inHand: 1, inReserve: 4);
			AssertMaximumCarryingCapacity(inHand: 2, inReserve: 3);
		}

		private void AssertMaximumCarryingCapacity(ushort inHand, ushort inReserve)
		{
			var s = new Survivor("Steve");

			for (int i = 0; i < inReserve; i++)
				Assert.IsTrue(s.PutInReserve(new DummyEquipment()), "Should be able to carry more items in reserve");

			for (int i = 0; i < inHand; i++)
				Assert.IsTrue(s.PutInHand(new DummyEquipment()), "Should be able to carry more items in hand");

			Assert.IsFalse(s.PutInReserve(new DummyEquipment()), "Should not be able to carry any more items in reserve");
			Assert.IsFalse(s.PutInHand(new DummyEquipment()), "Should not be able to carry any more items in hand");
		}

		private class DummyEquipment : IEquipment
		{
		}
	}
}
