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
	}
}
