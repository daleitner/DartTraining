using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using DartTraining.Match;

namespace DartTraining.Switcher
{
	public interface IContextSwitcher
	{
		MainViewModel GetMainScreen();
		void CloseApplication();
		void UserLoggedIn(string user, bool isNewUser);
		void OpenNewGame();
		void OpenMainMenu();
		void StartMatch(MatchConfig matchConfig);
	}
}
