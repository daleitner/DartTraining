﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace DartTraining.Switcher
{
	public interface IContextSwitcher
	{
		MainViewModel GetMainScreen();
		void CloseApplication();
		void UserLoggedIn(string user, bool isNewUser);
	}
}
