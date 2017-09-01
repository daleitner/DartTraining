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
			WpfApprovals.Verify(WindowGenerator.GenerateWindow(new MatchConfigViewModel(this.controller.Object), 1024, 768, "DartTraining"));
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
		public void WhenCreateViewModelThenVerifyGetAllLevels()
		{
			this.controller.Setup(x => x.GetAllLevels()).Returns(new List<int> { 1, 2, 3 });
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			this.controller.Verify(x => x.GetAllLevels(), Times.Once, "GetAllLevels was not called");
			Approvals.VerifyAll(viewModel.Levels, "Level");
		}

		[TestMethod]
		public void WhenCreateViewModelThenVerifyCanStart()
		{
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			Approvals.Verify("Start Button enabled = " + viewModel.StartCommand.CanExecute(null));
		}

		[TestMethod]
		public void WhenUserClickedBackThenVerifyBack()
		{
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			viewModel.BackCommand.Execute(null);
			this.controller.Verify(x => x.Back(), Times.Once, "Back was not called");
		}

		[TestMethod]
		public void WhenCPUOpponentIsSelectedThenVerifyCanStart()
		{
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			viewModel.SelectedOpponent = "Opponent1";
			viewModel.SelectedLevel = 1;
			Approvals.Verify("Start Button enabled = " + viewModel.StartCommand.CanExecute(null));
		}

		[TestMethod]
		public void WhenHumanOpponentIsSelectedThenVerifyCanStart()
		{
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			viewModel.IsPlayer = true;
			viewModel.IsCPU = false;
			viewModel.Player = "player";
			Approvals.Verify("Start Button enabled = " + viewModel.StartCommand.CanExecute(null));
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
			this.controller.Setup(x => x.GetRandomOpponent(It.IsAny<List<string>>())).Returns("RandomOpponent");
			var viewModel = new MatchConfigViewModel(this.controller.Object);
			viewModel.RandomCommand.Execute(null);
			this.controller.Verify(x => x.GetRandomOpponent(viewModel.Opponents), Times.Once, "GetRandomOpponent was not called");
			Approvals.Verify("SelectedOpponent = " + viewModel.SelectedOpponent);
		}
	}
}
