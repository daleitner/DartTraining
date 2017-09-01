using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using DartTraining.Match;
using DartTraining.Services;
using DartTraining.Switcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DartTrainingTests.Match
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class MatchConfigControllerTests
	{
		private Mock<IContextSwitcher> switcher;
		private Mock<IDataBaseService> dataBase;

		[TestInitialize]
		public void Setup()
		{
			this.switcher = new Mock<IContextSwitcher>();
			this.dataBase = new Mock<IDataBaseService>();
		}
		[TestMethod]
		public void VerifyBack()
		{
			var controller = new MatchConfigController(this.switcher.Object, this.dataBase.Object);
			controller.Back();
			this.switcher.Verify(x => x.OpenMainMenu(), Times.Once, "GetMainMenu was not called");
		}

		[TestMethod]
		public void VerifyGetAllOpponents()
		{
			var controller = new MatchConfigController(this.switcher.Object, this.dataBase.Object);
			controller.GetAllOpponents();
			this.dataBase.Verify(x => x.GetOpponents(), Times.Once, "Opponents was not fetched from database");
		}

		[TestMethod]
		public void VerifyGetRandomOpponent()
		{
			var list = new List<string> {"player1", "player2", "player3"};
			var controller = new MatchConfigController(this.switcher.Object, this.dataBase.Object);
			var opponent = controller.GetRandomOpponent(list);
			Approvals.Verify(list.Contains(opponent) ? "opponent is in list" : "opponent is not in list");
		}

		[TestMethod]
		public void VerifyGetAllLevels()
		{
			var controller = new MatchConfigController(this.switcher.Object, this.dataBase.Object);
			controller.GetAllLevels();
			this.dataBase.Verify(x => x.GetLevels(), Times.Once, "Levels was not fetched from database");
		}
	}
}
