using System;
using DartTraining.Login;
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

		public LoginViewModel CreateLoginViewModel()
		{
			return new LoginViewModel(this.contextSwitcher);
		}
	}
}
