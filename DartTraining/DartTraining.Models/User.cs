using System.Collections.Generic;
using Base;

namespace DartTraining.Models
{
	public sealed class User : ModelBase
	{
		public User(string name)
		{
			Name = name;
		}
		public User(List<string> itemList)
		{
			Id = itemList[0];
			Name = itemList[1];
		}
		public string Name { get; set; }
	}
}
