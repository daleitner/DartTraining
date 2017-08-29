using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using DartTraining.Match;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestBase;

namespace DartTrainingTests.Match
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class MatchConfigViewModelTests
	{
		private Mock<IMatchConfigController> controller;

		[TestInitialize]
		public void Setup()
		{
			this.controller = new Mock<IMatchConfigController>();
		}

		[TestMethod]
		[UseReporter(typeof(TortoiseImageDiffReporter), typeof(ClipboardReporter))]
		public void VerifyMatchConfigView()
		{
			WpfApprovals.Verify(WindowGenerator.GenerateWindow(new MatchConfigViewModel(this.controller.Object), "DartTraining"));
		}

		[TestMethod]
		public void WhenCreateViewModelThenVerifyGetAllOpponents()
		{
			this.controller.Setup(x => x.GetAllOpponents()).Returns(new List<string> { "Opponent1", "Opponent2", "Opponent3"});
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			this.controller.Verify(x => x.GetAllOpponents(), Times.Once, "GetAllOpponents was not called");
			Approvals.VerifyAll(viewModel.Opponents, "Opponent");
		}

		[TestMethod]
		public void WhenUserClickedBackThenVerifyBack()
		{
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			viewModel.BackCommand.Execute(null);
			this.controller.Verify(x => x.Back(), Times.Once, "Back was not called");
		}

		[TestMethod]
		public void WhenUserClickedStartThenVerifyStart()
		{
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			viewModel.StartCommand.Execute(null);
			this.controller.Verify(x => x.Start(), Times.Once, "Start was not called");
		}

		[TestMethod]
		public void WhenUserClickedRandomThenRandomOpponentShouldBeChosen()
		{
			this.controller.Setup(x => x.GetRandomOpponent()).Returns("RandomOpponent");
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			viewModel.RandomCommand.Execute(null);
			this.controller.Verify(x => x.GetRandomOpponent(), Times.Once, "GetRandomOpponent was not called");
			Approvals.Verify("SelectedOpponent = " + viewModel.SelectedOpponent);
		}
	}
}
