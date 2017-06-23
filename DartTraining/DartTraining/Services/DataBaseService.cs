using System.Collections.Generic;
using DBInterface;

namespace DartTraining.Services
{
	public class DataBaseService : IDataBaseService
	{
		private DataBaseManager dataBase;
		public DataBaseService()
		{
			this.dataBase = DataBaseManager.GetInstance();
		}

		public List<string> GetUsers()
		{
			return new List<string>();
		}

		public void InsertNewUser(string name)
		{
			//TODO
		}
	}
}
