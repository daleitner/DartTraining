using Base;
using DartTraining.Factory;

namespace DartTraining.Switcher
{
	public class ContextSwitcher : IContextSwitcher
	{
		private IViewModelFactory factory;

		public ContextSwitcher(IViewModelFactory factory)
		{
			this.factory = factory;
		}

		public ViewModelBase GetMainScreen()
		{
			return this.factory.CreateMenuViewModel();
		}

		public void CloseApplication()
		{
			this.factory.CloseApplication();
		}
	}
}
