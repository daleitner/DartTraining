using System.Collections.Generic;
using Base;
using DartTraining.Login;
using DartTraining.Menu;

namespace DartTraining.Factory
{
	public interface IViewModelFactory
	{
		MainViewModel CreateMainViewModel();
		MenuViewModel CreateMenuViewModel();
		LoginViewModel CreateLoginViewModel(List<string> users);
	}
}
