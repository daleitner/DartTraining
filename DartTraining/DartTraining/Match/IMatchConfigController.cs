using System.Collections.Generic;

namespace DartTraining.Match
{
	public interface IMatchConfigController
	{
		void Back();
		void Start(MatchConfig config);
		string GetRandomOpponent(List<string> opponents);
		List<string> GetAllOpponents();
		List<int> GetAllLevels();
	}
}

