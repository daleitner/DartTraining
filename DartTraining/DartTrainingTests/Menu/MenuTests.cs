using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using DartTraining.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DartTrainingTests.Menu
{
	[TestClass]
	[UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]
	public class MenuTests
	{
		[TestMethod]
		public void MenuGuiTest()
		{
			var view = new MenuUserControl();
			view.Height = 300;
			view.Width = 300;
			WpfApprovals.Verify(view);
		}
	}
}
