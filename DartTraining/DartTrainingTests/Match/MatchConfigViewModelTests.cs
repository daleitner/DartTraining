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

namespace DartTrainingTests.Match
{
	[TestClass]
	[UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
	public class MatchConfigViewModelTests
	{
		private Mock<IContextSwitcher> contextSwitcher;

		[TestInitialize]
		public void Setup()
		{
			this.contextSwitcher = new Mock<IContextSwitcher>();
		}

		[TestMethod]
		public void VerifyMatchConfigView()
		{
			WpfApprovals.Verify(WindowGenerator.GenerateWindow(new MatchConfigViewModel(this.contextSwitcher.Object)));
		}
	}
}
