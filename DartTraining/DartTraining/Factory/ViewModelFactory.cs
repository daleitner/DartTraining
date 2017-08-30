using System;
using System.Collections.Generic;
using DartTraining.Login;
using DartTraining.Match;
using DartTraining.Menu;
using DartTraining.Services;
using DartTraining.Switcher;

namespace DartTraining.Factory
{
	public class ViewModelFactory : IViewModelFactory
	{
		private readonly IContextSwitcher contextSwitcher;
		private readonly IDataBaseService dataBaseService;
		
		public ViewModelFactory(IContextSwitcher contextSwitcher, IDataBaseService dataBaseService)
		{
			this.contextSwitcher = contextSwitcher;
			this.dataBaseService = dataBaseService;
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
			var controller = new MatchConfigController(this.contextSwitcher, this.dataBaseService);
			return new MatchConfigViewModel(controller);
		}
	}
}
