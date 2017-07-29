using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using DartTraining.Match;
using DartTraining.Switcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestBase;

namespace DartTrainingTests.Match
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class MatchConfigViewModelTests
	{
		private Mock<IContextSwitcher> contextSwitcher;

		[TestInitialize]
		public void Setup()
		{
			this.contextSwitcher = new Mock<IContextSwitcher>();
		}

		[TestMethod]
		[UseReporter(typeof(TortoiseImageDiffReporter), typeof(ClipboardReporter))]
		public void VerifyMatchConfigView()
		{
			WpfApprovals.Verify(WindowGenerator.GenerateWindow(new MatchConfigViewModel(new MatchConfigController(this.contextSwitcher.Object)), "DartTraining"));
		}
	}
}
