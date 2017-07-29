using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using DartTraining.Factory;
using DartTraining.Menu;
using DartTraining.Switcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestBase;

namespace DartTrainingTests.Menu
{
	[TestClass]
	[UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
	public class MenuTests
	{
		private Mock<IContextSwitcher> contextSwitcher;

		[TestInitialize]
		public void Setup()
		{
			this.contextSwitcher = new Mock<IContextSwitcher>();
		}
		[TestMethod]
		public void MenuGuiTest()
		{
			WpfApprovals.Verify(WindowGenerator.GenerateWindow(new MenuViewModel(this.contextSwitcher.Object), "DartTraining"));
		}

		[TestMethod]
		public void WhenClickBeenden_ThenCloseApplicationShouldBeCalled()
		{
			var viewModel = new MenuViewModel(this.contextSwitcher.Object);
			viewModel.CloseCommand.Execute(null);

			this.contextSwitcher.Verify(x => x.CloseApplication(), Times.Once, "context switcher did not close application");
		}

		[TestMethod]
		public void WhenClickTrainingsspiel_ThenOpenNewGameShouldBeCalled()
		{
			var viewModel = new MenuViewModel(this.contextSwitcher.Object);
			viewModel.StartGameCommand.Execute(null);

			this.contextSwitcher.Verify(x => x.OpenNewGame(), Times.Once, "context switcher did not open new game");
		}
	}
}
