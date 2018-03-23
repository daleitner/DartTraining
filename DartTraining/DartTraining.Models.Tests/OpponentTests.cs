using ApprovalTests;
using ApprovalTests.Reporters;
using Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DartTraining.Models.Tests
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class OpponentTests
	{
		protected Opponent SUT;

		[TestInitialize]
		public void Setup()
		{
			IdGenerator.PrepareGeneratorForTest(0);
		}

		[TestMethod]
		public void WhenCreateOpponent_ThenVerifySUT()
		{
			SUT = new Opponent("some","player");
			Approvals.Verify(SUT.ToPrettyString());
		}

		[TestMethod]
		public void VerifyToString()
		{
			SUT = new Opponent("some", "player");
			Approvals.Verify(SUT.ToString());
		}
	}
}
