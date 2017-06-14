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
			WpfApprovals.Verify(WindowGenerator.GenerateWindow(new LoginViewModel(this.contextSwitcher.Object)));
		}

		[TestMethod]
		public void WhenNewUserIsEmptyAndSelectedUserIsNull_ThenLoginButtonShouldBeDisabled()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object);
			Approvals.Verify("Button Enabled: " + viewModel.LoginCommand.CanExecute(null));
		}

		[TestMethod]
		public void WhenNewUserIsEmptyAndSelectedUserIsSet_ThenLoginButtonShouldBeEnabled()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object);
			viewModel.SelectedUser = "name";
			Approvals.Verify("Button Enabled: " + viewModel.LoginCommand.CanExecute(null));
		}

		[TestMethod]
		public void WhenNewUserIsSetAndSelectedUserIsNull_ThenLoginButtonShouldBeEnabled()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object);
			viewModel.NewUser = "name";
			Approvals.Verify("Button Enabled: " + viewModel.LoginCommand.CanExecute(null));
		}

		[TestMethod]
		public void WhenNewUserIsSetAndSelectedUserIsSet_ThenLoginButtonShouldBeEnabled()
		{
			var viewModel = new LoginViewModel(this.contextSwitcher.Object);
			viewModel.SelectedUser = "name";
			viewModel.NewUser = "name";
			Approvals.Verify("Button Enabled: " + viewModel.LoginCommand.CanExecute(null));
		}
	}
}
