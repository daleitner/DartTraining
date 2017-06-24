using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace DartTraining.Models
{
	public class User : ModelBase
	{
		public User(string name)
		{
			this.Name = name;
		}

		public User(List<string> itemList)
		{
			this.Id = itemList[0];
			this.Name = itemList[1];
		}
		
		public string Name { get; set; }
	}
}
