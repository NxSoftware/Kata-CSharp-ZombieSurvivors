using System;
namespace ZombieSurvivors
{
	public class Survivor
	{
		private readonly string _name;
		public string Name
		{
			get
			{
				return _name;
			}
		}

		private ushort _numberOfWounds = 0;
		public ushort NumberOfWounds
		{
			get
			{
				return _numberOfWounds;
			}
			private set
			{
				if (IsDead == false)
				{
					_numberOfWounds = value;
				}
			}
		}

		public bool IsDead
		{
			get
			{
				return _numberOfWounds == 2;
			}
		}

		public Survivor(string name)
		{
			_name = name;
		}

		public void Wound()
		{
			NumberOfWounds += 1;
		}
	}
}
