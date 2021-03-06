﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ZombieSurvivors
{
	public class Survivor
	{
		private const ushort MaximumNumberOfWounds = 2;
		private const ushort NumberOfStartingActions = 3;
		private ushort _maximumEquipmentInHand = 2;
		private const ushort MaximumEquipmentInReserve = 5;
		private const ushort MaximumTotalEquipment = 5;

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

		private IList<IEquipment> _equipmentInHand;
		private IList<IEquipment> _equipmentInReserve;

		public Survivor(string name)
		{
			_name = name;
			_equipmentInHand = new List<IEquipment>();
			_equipmentInReserve = new List<IEquipment>();
		}

		public void Wound()
		{
			if (IsDead == false)
			{
				NumberOfWounds += 1;
				if (NumberOfWounds == MaximumNumberOfWounds)
				{
					IsDead = true;
				}
				else
				{
					_maximumEquipmentInHand -= 1;

					if (_equipmentInHand.Count > _maximumEquipmentInHand)
					{
						var heaviestInHand = _equipmentInHand.OrderByDescending(e => e.Weight).FirstOrDefault();
						var heaviestInReserve = _equipmentInReserve.OrderByDescending(e => e.Weight).FirstOrDefault();

						_equipmentInHand.Remove(heaviestInHand);

						if (heaviestInReserve?.Weight > heaviestInHand.Weight)
						{
							_equipmentInReserve.Remove(heaviestInReserve);
							_equipmentInReserve.Add(heaviestInHand);
						}
					}
					else
					{
						var allEquipment = _equipmentInHand.Concat(_equipmentInReserve);
						var heaviestEquipment = allEquipment.OrderByDescending(e => e.Weight).FirstOrDefault();
						if (heaviestEquipment != null)
						{
							_equipmentInHand.Remove(heaviestEquipment);
							_equipmentInReserve.Remove(heaviestEquipment);
						}
					}
				}
			}
		}

		public bool PutInHand(IEquipment equipment)
		{
			return Carry(equipment, _equipmentInHand, _maximumEquipmentInHand);
		}

		public bool PutInReserve(IEquipment equipment)
		{
			return Carry(equipment, _equipmentInReserve, MaximumEquipmentInReserve);
		}

		private bool Carry(IEquipment equipment, ICollection<IEquipment> container, ushort maximumCapacity)
		{
			if (container.Count == maximumCapacity)
				return false;

			if (IsAtMaximumCarryingCapacity())
				return false;

			container.Add(equipment);
			return true;
		}

		private bool IsAtMaximumCarryingCapacity()
		{
			return _equipmentInHand.Count + _equipmentInReserve.Count == MaximumTotalEquipment;
		}

		public IEquipment GetInHandEquipment(int index)
		{
			return _equipmentInHand.ElementAtOrDefault(index);
		}

		public IEquipment GetReserveEquipment(int index)
		{
			return _equipmentInReserve.ElementAtOrDefault(index);
		}
	}
}
