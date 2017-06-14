using System;
using DartTraining.Menu;
using DartTraining.Switcher;

namespace DartTraining.Factory
{
	public class ViewModelFactory : IViewModelFactory
	{
		private readonly IContextSwitcher contextSwitcher;
		public event EventHandler CloseEvent;
		public ViewModelFactory()
		{
			this.contextSwitcher = new ContextSwitcher(this);
		}
		public MainViewModel CreateMainViewModel()
		{
			return new MainViewModel(this.contextSwitcher);
		}

		public MenuViewModel CreateMenuViewModel()
		{
			return new MenuViewModel(this.contextSwitcher);
		}

		public void CloseApplication()
		{
			CloseEvent?.Invoke(null, null);
		}
	}
}
