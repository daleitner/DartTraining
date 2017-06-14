using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using DartTraining;
using DartTraining.Menu;
using DartTraining.Switcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DartTrainingTests
{
	[TestClass]
	[UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
	public class MainViewModelTests
	{
		private Mock<IContextSwitcher> contextSwitcher;
		[TestInitialize]
		public void Setup()
		{
			this.contextSwitcher = new Mock<IContextSwitcher>();
		}
		[TestMethod]
		public void WhenCreateMainViewModel_ThenContextShouldBeMainMenu()
		{
			this.contextSwitcher.Setup(x => x.GetMainScreen()).Returns(new MenuViewModel(this.contextSwitcher.Object));
			var viewModel = new MainViewModel(this.contextSwitcher.Object);
			this.contextSwitcher.Verify(x => x.GetMainScreen(), Times.Once, "Main Screen was not requested");
			Approvals.Verify("Context = " + viewModel.Context);
		}
	}
}
