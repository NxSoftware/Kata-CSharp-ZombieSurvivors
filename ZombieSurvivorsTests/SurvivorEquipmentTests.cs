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

		[Test]
		public void ReceivingAWoundDecreasesInHandEquipmentCapacity()
		{
			var s = new Survivor("Steve");
			s.Wound();
			Assert.IsTrue(s.PutInHand(new DummyEquipment()));
			Assert.IsFalse(s.PutInHand(new DummyEquipment()));
		}

		[Test]
		public void ReceivingAWoundWhileCarryingOnly2PiecesOfEquipmentInHandDropsTheHeaviest()
		{
			var s = new Survivor("Steve");
			s.PutInHand(new DummyEquipment(weight: 10));
			s.PutInHand(new DummyEquipment(weight: 9));
			s.Wound();
			Assert.AreEqual(9, s.GetInHandEquipment(0).Weight);
			Assert.IsNull(s.GetInHandEquipment(1));
		}

		[Test]
		public void ReceivingAWoundWhileCarryingOnly5PiecesOfEquipmentInReserveDropsTheHeaviest()
		{
			var s = new Survivor("Steve");
			s.PutInReserve(new DummyEquipment(weight: 10));
			s.PutInReserve(new DummyEquipment(weight: 9));
			s.PutInReserve(new DummyEquipment(weight: 8));
			s.PutInReserve(new DummyEquipment(weight: 7));
			s.PutInReserve(new DummyEquipment(weight: 6));
			s.Wound();
			Assert.AreEqual(9, s.GetReserveEquipment(0).Weight);
			Assert.AreEqual(8, s.GetReserveEquipment(1).Weight);
			Assert.AreEqual(7, s.GetReserveEquipment(2).Weight);
			Assert.AreEqual(6, s.GetReserveEquipment(3).Weight);
			Assert.IsNull(s.GetReserveEquipment(4));
		}

		[Test]
		public void ReceivingAWoundWhileCarryingHeaviestItemInReserveDropsThatItem()
		{
			var s1 = new Survivor("Steve");
			s1.PutInHand(new DummyEquipment(weight: 9));
			s1.PutInReserve(new DummyEquipment(weight: 10));
			s1.PutInReserve(new DummyEquipment(weight: 8));
			s1.PutInReserve(new DummyEquipment(weight: 7));
			s1.PutInReserve(new DummyEquipment(weight: 6));
			s1.Wound();
			Assert.AreEqual(9, s1.GetInHandEquipment(0).Weight);
			Assert.AreEqual(8, s1.GetReserveEquipment(0).Weight);
			Assert.AreEqual(7, s1.GetReserveEquipment(1).Weight);
			Assert.AreEqual(6, s1.GetReserveEquipment(2).Weight);
			Assert.IsNull(s1.GetReserveEquipment(3));
		}

		[Test]
		public void ReceivingAWoundWhileCarryingHeaviestItemInHandDropsThatItem()
		{
			var s2 = new Survivor("Steve");
			s2.PutInHand(new DummyEquipment(weight: 10));
			s2.PutInReserve(new DummyEquipment(weight: 9));
			s2.PutInReserve(new DummyEquipment(weight: 8));
			s2.PutInReserve(new DummyEquipment(weight: 7));
			s2.PutInReserve(new DummyEquipment(weight: 6));
			s2.Wound();
			Assert.IsNull(s2.GetInHandEquipment(0));
			Assert.AreEqual(9, s2.GetReserveEquipment(0).Weight);
			Assert.AreEqual(8, s2.GetReserveEquipment(1).Weight);
			Assert.AreEqual(7, s2.GetReserveEquipment(2).Weight);
			Assert.AreEqual(6, s2.GetReserveEquipment(3).Weight);
		}

		[Test]
		public void ReceivingAWoundWhileCarrying2InHandAnd3InReserveDropsTheHeaviestInHand()
		{
			var s = new Survivor("Steve");
			s.PutInHand(new DummyEquipment(weight: 9));
			s.PutInHand(new DummyEquipment(weight: 10));
			s.PutInReserve(new DummyEquipment(weight: 11));
			s.PutInReserve(new DummyEquipment(weight: 8));
			s.PutInReserve(new DummyEquipment(weight: 7));
			s.Wound();
			Assert.AreEqual(9, s.GetInHandEquipment(0).Weight);
			Assert.IsNull(s.GetInHandEquipment(1));
			Assert.AreEqual(11, s.GetReserveEquipment(0).Weight);
			Assert.AreEqual(8, s.GetReserveEquipment(1).Weight);
			Assert.AreEqual(7, s.GetReserveEquipment(2).Weight);
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
			public short Weight { get; private set; }

			public DummyEquipment(short weight = 0)
			{
				Weight = weight;
			}
		}
	}
}
