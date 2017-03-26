using ZombieSurvivors;
using NUnit.Framework;

namespace ZombieSurvivorsTests
{
	public class SurvivorEquipmentTests
	{
		[Test]
		public void SurvivorCanCarryUpTo5PiecesOfEquipment()
		{
			var s = new Survivor("Steve");
			Assert.AreEqual(5, s.NumberOfEmptyEquipmentSlots);
		}

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

		private class DummyEquipment : IEquipment
		{
		}
	}
}
