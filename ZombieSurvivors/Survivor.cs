using System;
using System.Collections.Generic;

namespace ZombieSurvivors
{
	public class Survivor
	{
		private const ushort MaximumNumberOfWounds = 2;
		private const ushort NumberOfStartingActions = 3;

		private readonly string _name;
		public string Name
		{
			get
			{
				return _name;
			}
		}

		public ushort NumberOfWounds { get; private set; }
		public bool IsDead { get; private set; }
		public ushort NumberOfRemainingActions { get; private set; } = NumberOfStartingActions;
		public ushort NumberOfEmptyEquipmentSlots { get; private set; } = 5;

		private List<IEquipment> _equipmentInHand;

		public Survivor(string name)
		{
			_name = name;
			_equipmentInHand = new List<IEquipment>();
		}

		public void Wound()
		{
			if (IsDead == false)
			{
				NumberOfWounds += 1;
				if (NumberOfWounds == MaximumNumberOfWounds)
					IsDead = true;
			}
		}

		public bool PutInHand(IEquipment equipment)
		{
			if (_equipmentInHand.Count == 2)
				return false;

			_equipmentInHand.Add(equipment);
			return true;
		}
	}
}
