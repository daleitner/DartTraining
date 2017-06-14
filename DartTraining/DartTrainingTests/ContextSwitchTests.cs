using System;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using DartTraining;
using DartTraining.Factory;
using DartTraining.Menu;
using DartTraining.Switcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DartTrainingTests
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
		public void WhenContextSwitcherCloseApplication_ThenFactoryShouldCloseApplication()
		{
			var switcher = new ContextSwitcher(this.factory.Object);
			switcher.CloseApplication();
			this.factory.Verify(x => x.CloseApplication(), Times.Once, "factory did not close application");
		}
	}
}
