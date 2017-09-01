using System.Collections.Generic;

namespace DartTraining.Match
{
	public interface IMatchConfigController
	{
		void Back();
		void Start();
		string GetRandomOpponent(List<string> opponents);
		List<string> GetAllOpponents();
		List<int> GetAllLevels();
	}
}

