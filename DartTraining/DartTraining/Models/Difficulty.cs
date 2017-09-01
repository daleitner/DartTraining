using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace DartTraining.Models
{
	public class Difficulty : ModelBase
	{
		public Difficulty(int level)
		{
			this.Level = level;
		}

		public Difficulty(List<string> itemList)
		{
			this.Id = itemList[0];
			this.Level = Int32.Parse(itemList[1]);
		}

		public int Level { get; set; }

	}
}
