using System.Collections.Generic;

namespace DartTraining.Services
{
	public interface IDataBaseService
	{
		List<string> GetUsers();
		void InsertNewUser(string name);
		List<string> GetOpponents();
		List<int> GetLevels();
	}
}
