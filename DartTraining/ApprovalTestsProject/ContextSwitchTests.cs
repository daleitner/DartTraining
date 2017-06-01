using System;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using DartTraining;
using DartTraining.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApprovalTestsProject
{
	[TestClass]
	[UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
	public class ContextSwitchTests
	{
		[TestMethod]
		public void ShowMenuWhenStartMainWindow()
		{
			var window = new MainWindow();
			WpfApprovals.Verify(window);
		}
	}
}
