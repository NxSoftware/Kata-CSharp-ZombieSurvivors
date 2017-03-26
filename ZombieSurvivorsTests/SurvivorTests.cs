using System;
using ZombieSurvivors;
using NUnit.Framework;

namespace ZombieSurvivorsTests
{
	public class SurvivorTests
	{
		private Survivor sut;

		[SetUp]
		public void Setup()
		{
			sut = new Survivor("Steve");
		}

		[Test]
		public void CanCreateSurvivor()
		{
			Assert.AreEqual("Steve", sut.Name);
			Assert.AreEqual(0, sut.NumberOfWounds);
			Assert.IsFalse(sut.IsDead);
			Assert.AreEqual(3, sut.NumberOfRemainingActions);
		}

		[Test]
		public void CanWoundSurvivor()
		{
			sut.Wound();
			Assert.AreEqual(1, sut.NumberOfWounds);
		}

		[Test]
		public void SurvivorWithTwoWoundsDies()
		{
			sut.Wound();
			Assert.IsFalse(sut.IsDead);
			sut.Wound();
			Assert.IsTrue(sut.IsDead);
		}

		[Test]
		public void WoundsReceivedAfterDyingAreIgnored()
		{
			sut.Wound();
			sut.Wound();
			sut.Wound();
			Assert.AreEqual(2, sut.NumberOfWounds);
		}
	}
}
