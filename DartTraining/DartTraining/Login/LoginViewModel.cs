using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Base;
using DartTraining.Switcher;

namespace DartTraining.Login
{
	public class LoginViewModel : ViewModelBase
	{
		private RelayCommand loginCommand;
		private ObservableCollection<string> users;
		private string selectedUser;
		private string newUser;
		private readonly IContextSwitcher contextSwitcher;

		public LoginViewModel(IContextSwitcher contextSwitcher)
		{
			this.users = new ObservableCollection<string>();
			this.contextSwitcher = contextSwitcher;
		}

		public ObservableCollection<string> Users
		{
			get { return this.users; }
			set
			{
				this.users = value;
				OnPropertyChanged(nameof(this.Users));
			}
		}
		public string SelectedUser
		{
			get { return this.selectedUser; }
			set
			{
				this.selectedUser = value;
				OnPropertyChanged(nameof(this.SelectedUser));
			}
		}
		public string NewUser
		{
			get { return this.newUser; }
			set
			{
				this.newUser = value;
				OnPropertyChanged(nameof(this.NewUser));
			}
		}
		public ICommand LoginCommand
		{
			get
			{
				return this.loginCommand ?? (this.loginCommand = new RelayCommand(param => Login(), param => CanLogin()));
			}
		}

		private void Login()
		{
			
		}

		private bool CanLogin()
		{
			return !string.IsNullOrEmpty(this.SelectedUser) || !string.IsNullOrEmpty(this.NewUser);
		}
	}
}
