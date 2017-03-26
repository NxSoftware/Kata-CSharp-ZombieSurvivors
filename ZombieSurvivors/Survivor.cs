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

		public Survivor(string name)
		{
			_name = name;
		}
	}
}
