using ApprovalTests;
using ApprovalTests.Reporters;
using DartTraining.Factory;
using DartTraining.Switcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DartTrainingTests.Switcher
{
	[TestClass]
	[UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
	public class ContextSwitchTests
	{
		private Mock<IViewModelFactory> factory;

		[TestInitialize]
		public void Setup()
		{
			this.factory = new Mock<IViewModelFactory>();
		}

		[TestMethod]
		public void WhenGetMainScreen_ThenContextShouldBeLoginViewModel()
		{
			var contextSwitcher = new ContextSwitcher();
			var viewModel = contextSwitcher.GetMainScreen();
			Approvals.Verify("Content = " + viewModel.Context);
		}
	}
}
