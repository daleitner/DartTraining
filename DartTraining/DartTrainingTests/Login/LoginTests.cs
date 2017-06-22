using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using DartTraining.Login;
using DartTraining.Switcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DartTrainingTests.Login
{
	[TestClass]
	[UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
	public class LoginTests
	{
		private Mock<IContextSwitcher> contextSwitcher;
		[TestInitialize]
		public void Setup()
		{
			this.contextSwitcher = new Mock<IContextSwitcher>();
		}
		[TestMethod]
		public void LoginGuiTest()
		{
			WpfApprovals.Verify(WindowGenerator.GenerateWindow(new LoginViewModel(this.contextSwitcher.Object, new List<string>() {"user1", "user2", "user3"})));
		}

		[TestMethod]
		public void WhenNewUserIsEmpty_ThenLoginButtonShouldBeDisabled()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object, new List<string>());
			Approvals.Verify("Button Enabled: " + viewModel.LoginCommand.CanExecute(null));
		}

		[TestMethod]
		public void WhenNewUserIsSet_ThenLoginButtonShouldBeEnabled()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object, new List<string>());
			viewModel.NewUser = "name";
			Approvals.Verify("Button Enabled: " + viewModel.LoginCommand.CanExecute(null));
		}

		[TestMethod]
		public void WhenSelectedUserIsSet_ThenNewUserShouldBeSelectedUser()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object, new List<string>());
			viewModel.SelectedUser = "name";
			Approvals.Verify("User in Textbox: " + viewModel.NewUser);
		}

		[TestMethod]
		public void WhenSelectedUserIsSetAndNewUserIsSet_ThenNewUserShouldBeSelectedUser()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object, new List<string>());
			viewModel.NewUser = "new User";
			viewModel.SelectedUser = "name";
			Approvals.Verify("User in Textbox: " + viewModel.NewUser);
		}

		[TestMethod]
		public void WhenUserIsSetAndLoginClicked_ThenNotifyContextSwitcher()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object, new List<string>());
			viewModel.NewUser = "name";
			viewModel.LoginCommand.Execute(null);
			this.contextSwitcher.Verify(x => x.UserLoggedIn(viewModel.NewUser, true), Times.Once, "ContextSwitcher was not notified");
		}

		[TestMethod]
		public void WhenUserIsSetFromListBoxAndLoginClicked_ThenNotifyContextSwitcher()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object, new List<string> {"user1"});
			viewModel.NewUser = "name";
			viewModel.SelectedUser = viewModel.Users.First();
			viewModel.LoginCommand.Execute(null);
			this.contextSwitcher.Verify(x => x.UserLoggedIn(viewModel.NewUser, false), Times.Once, "ContextSwitcher was not notified");
		}
	}
}
