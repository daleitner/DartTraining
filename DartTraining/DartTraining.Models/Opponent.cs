using System.Collections.Generic;
using Base;

namespace DartTraining.Models
{
	public sealed class Opponent : ModelBase
	{
		public Opponent(string name, string lastName)
		{
			Name = name;
			LastName = lastName;
		}

		public Opponent(List<string> itemList)
		{
			Id = itemList[0];
			Name = itemList[1];
			LastName = itemList[2];
		}
		public string Name { get; set; }
		public string LastName { get; set; }

		public override string ToString()
		{
			return Name + " " + LastName;
		}
	}
}
