using System;
using ZombieSurvivors;
using NUnit.Framework;

namespace ZombieSurvivorsTests
{
	public class SurvivorTests
	{
		[Test]
		public void CanCreateSurvivor()
		{
			var s = new Survivor("Steve");
			Assert.AreEqual("Steve", s.Name);
			Assert.AreEqual(0, s.NumberOfWounds);
			Assert.IsFalse(s.IsDead);
		}

		[Test]
		public void CanWoundSurvivor()
		{
			var s = new Survivor("Steve");
			s.Wound();
			Assert.AreEqual(1, s.NumberOfWounds);
		}

		[Test]
		public void SurvivorWithTwoWoundsDies()
		{
			var s = new Survivor("Steve");
			s.Wound();
			s.Wound();
			Assert.IsTrue(s.IsDead);
		}
	}
}
