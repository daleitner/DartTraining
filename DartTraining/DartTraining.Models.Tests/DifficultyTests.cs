using ApprovalTests;
using ApprovalTests.Reporters;
using Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DartTraining.Models.Tests
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class DifficultyTests
	{
		protected Difficulty SUT;

		[TestInitialize]
		public void Setup()
		{
			IdGenerator.PrepareGeneratorForTest(0);
		}

		[TestMethod]
		public void WhenCreateNewDifficulty_ThenVerifySUT()
		{
			var defaultLevel = 1;
			SUT = new Difficulty(defaultLevel);
			Approvals.Verify(SUT.ToPrettyString());
		}
	}
}
