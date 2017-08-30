using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace DartTraining.Models
{
	public class Opponent : ModelBase
	{
		public Opponent(string name, string lastName)
		{
			this.Name = name;
			this.LastName = lastName;
		}

		public Opponent(List<string> itemList)
		{
			this.Id = itemList[0];
			this.Name = itemList[1];
			this.LastName = itemList[2];
		}

		public string Name { get; set; }
		public string LastName { get; set; }

		public override string ToString()
		{
			return this.Name + " " + this.LastName;
		}
	}
}
