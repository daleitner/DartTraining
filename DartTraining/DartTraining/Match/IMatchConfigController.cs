using System.Collections.Generic;

namespace DartTraining.Match
{
	public interface IMatchConfigController
	{
		void Back();
		void Start();
		string GetRandomOpponent();
		List<string> GetAllOpponents();
	}
}

