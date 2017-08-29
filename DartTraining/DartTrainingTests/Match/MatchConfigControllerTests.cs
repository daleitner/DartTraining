using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests.Reporters;
using DartTraining.Match;
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

		[TestInitialize]
		public void Setup()
		{
			this.switcher = new Mock<IContextSwitcher>();
		}
		[TestMethod]
		public void VerifyBack()
		{
			var controller = new MatchConfigController(this.switcher.Object);
			controller.Back();
			this.switcher.Verify(x => x.GetMainMenu(), Times.Once, "GetMainMenu was not called");
		}
	}
}
