using System.Collections.Generic;
using System.Linq;
using DartTraining.Models;
using DBInterface;

namespace DartTraining.Services
{
	public class DataBaseService : IDataBaseService
	{
		private readonly DataBaseManager dataBase;
		public DataBaseService()
		{
			this.dataBase = DataBaseManager.GetInstance();
		}

		public List<string> GetUsers()
		{
			return this.dataBase.GetAll<User>().Select(x => x.Name).ToList();
		}

		public void InsertNewUser(string name)
		{
			this.dataBase.Insert(new User(name));
		}
	}
}
