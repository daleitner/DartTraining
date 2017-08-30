using System;
using System.Collections.Generic;
using Base;
using DartTraining.Factory;
using IDataBaseService = DartTraining.Services.IDataBaseService;

namespace DartTraining.Switcher
{
	public class ContextSwitcher : IContextSwitcher
	{
		private readonly IDataBaseService dataBaseService;
		private readonly IViewModelFactory factory;
		private readonly MainViewModel viewModel;
		public event EventHandler CloseEvent;
		public ContextSwitcher(IDataBaseService dataBaseService)
		{
			this.dataBaseService = dataBaseService;
			this.factory = new ViewModelFactory(this, this.dataBaseService);
			this.viewModel = this.factory.CreateMainViewModel();
		}

		public MainViewModel ViewModel => this.viewModel;

		public MainViewModel GetMainScreen()
		{
			var users = this.dataBaseService.GetUsers();
			SetContext(this.factory.CreateLoginViewModel(users));
			return this.viewModel;
		}

		public void CloseApplication()
		{
			CloseEvent?.Invoke(null,null);
		}

		public void UserLoggedIn(string user, bool isNewUser)
		{
			if(isNewUser)
				this.dataBaseService.InsertNewUser(user);
			SetContext(this.factory.CreateMenuViewModel());
		}

		private void SetContext(ViewModelBase context)
		{
			this.viewModel.Context = context;
		}

		public void OpenNewGame()
		{
			SetContext(this.factory.CreateMatchConfigViewModel());
		}

		public void OpenMainMenu()
		{
			SetContext(this.factory.CreateMenuViewModel());
		}
	}
}
