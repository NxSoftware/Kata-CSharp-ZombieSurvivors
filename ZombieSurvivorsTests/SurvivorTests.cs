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
		}
	}
}
