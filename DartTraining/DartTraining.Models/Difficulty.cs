using System.Collections.Generic;
using Base;

namespace DartTraining.Models
{
	public sealed class Difficulty : ModelBase
	{
		public Difficulty(List<string> itemList)
		{
			Id = itemList[0];
			Level = int.Parse(itemList[1]);
		}

		public Difficulty(int level)
		{
			Level = level;
		}

		public int Level { get; set; }

	}
}
