using System;
using Base;
using DartTraining.Factory;

namespace DartTraining.Switcher
{
	public class ContextSwitcher : IContextSwitcher
	{
		private readonly IViewModelFactory factory;
		private MainViewModel viewModel;
		public event EventHandler CloseEvent;
		public ContextSwitcher()
		{
			this.factory = new ViewModelFactory(this);
		}

		public MainViewModel GetMainScreen()
		{
			this.viewModel = this.factory.CreateMainViewModel();
			SetContext(this.factory.CreateLoginViewModel());
			return this.viewModel;
		}

		public void CloseApplication()
		{
			CloseEvent?.Invoke(null,null);
		}

		private void SetContext(ViewModelBase context)
		{
			this.viewModel.Context = context;
		}
	}
}
