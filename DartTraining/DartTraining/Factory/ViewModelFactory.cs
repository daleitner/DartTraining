using System;
using System.Collections.Generic;
using DartTraining.Login;
using DartTraining.Match;
using DartTraining.Menu;
using DartTraining.Switcher;

namespace DartTraining.Factory
{
	public class ViewModelFactory : IViewModelFactory
	{
		private readonly IContextSwitcher contextSwitcher;
		
		public ViewModelFactory(IContextSwitcher contextSwitcher)
		{
			this.contextSwitcher = contextSwitcher;
		}
		public MainViewModel CreateMainViewModel()
		{
			return new MainViewModel();
		}

		public MenuViewModel CreateMenuViewModel()
		{
			return new MenuViewModel(this.contextSwitcher);
		}

		public LoginViewModel CreateLoginViewModel(List<string> users)
		{
			return new LoginViewModel(this.contextSwitcher, users);
		}

		public MatchConfigViewModel CreateMatchConfigViewModel()
		{
			return new MatchConfigViewModel(this.contextSwitcher);
		}
	}
}
