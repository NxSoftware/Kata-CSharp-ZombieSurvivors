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
			// 1 in hand, 4 in reserve
			var s1 = new Survivor("Steve");
			Assert.IsTrue(s1.PutInHand(new DummyEquipment()));
			Assert.IsTrue(s1.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s1.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s1.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s1.PutInReserve(new DummyEquipment()));
			Assert.IsFalse(s1.PutInHand(new DummyEquipment()));
			Assert.IsFalse(s1.PutInReserve(new DummyEquipment()));

			// 2 in hand, 3 in reserve
			var s2 = new Survivor("Steve");
			Assert.IsTrue(s2.PutInHand(new DummyEquipment()));
			Assert.IsTrue(s2.PutInHand(new DummyEquipment()));
			Assert.IsTrue(s2.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s2.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s2.PutInReserve(new DummyEquipment()));
			Assert.IsFalse(s2.PutInReserve(new DummyEquipment()));

			// 5 in reserve, 0 in hand
			var s3 = new Survivor("Steve");
			Assert.IsTrue(s3.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s3.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s3.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s3.PutInReserve(new DummyEquipment()));
			Assert.IsTrue(s3.PutInReserve(new DummyEquipment()));
			Assert.IsFalse(s3.PutInHand(new DummyEquipment()));
		}

		private class DummyEquipment : IEquipment
		{
		}
	}
}
