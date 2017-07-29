using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using DartTraining.Services;
using DartTraining.Switcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DartTrainingTests.Switcher
{
	[TestClass]
	[UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
	public class ContextSwitchTests
	{
		private Mock<IDataBaseService> dataBaseService;

		[TestInitialize]
		public void Setup()
		{
			this.dataBaseService = new Mock<IDataBaseService>();
		}

		[TestMethod]
		public void WhenGetMainScreen_ThenContextShouldBeLoginViewModel()
		{
			this.dataBaseService.Setup(x => x.GetUsers()).Returns(new List<string>());
			var contextSwitcher = new ContextSwitcher(this.dataBaseService.Object);
			contextSwitcher.GetMainScreen();
			this.dataBaseService.Verify(x => x.GetUsers(), Times.Once, "Users was not fetched from Database");
			Approvals.Verify("Content = " + contextSwitcher.ViewModel.Context);
		}

		[TestMethod]
		public void WhenKnownUserLoggedIn_ThenContextShouldSwitchToMenu()
		{
			var contextSwitcher = new ContextSwitcher(this.dataBaseService.Object);
			contextSwitcher.UserLoggedIn("name", false);
			Approvals.Verify("Content = " + contextSwitcher.ViewModel.Context);
		}

		[TestMethod]
		public void WhenNewUserLoggedIn_ThenContextShouldSwitchToMenu()
		{
			var contextSwitcher = new ContextSwitcher(this.dataBaseService.Object);
			contextSwitcher.UserLoggedIn("name", true);
			this.dataBaseService.Verify(x => x.InsertNewUser("name"), Times.Once, "User was not inserted in Databae");
			Approvals.Verify("Content = " + contextSwitcher.ViewModel.Context);
		}

		[TestMethod]
		public void WhenStartNewGame_ThenMatchConfigShouldOpen()
		{
			var contextSwitcher = new ContextSwitcher(this.dataBaseService.Object);
			contextSwitcher.OpenNewGame();
			Approvals.Verify("Content = " + contextSwitcher.ViewModel.Context);
		}
	}
}
