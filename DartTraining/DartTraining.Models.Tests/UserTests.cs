using ApprovalTests;
using ApprovalTests.Reporters;
using Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DartTraining.Models.Tests
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class UserTests
	{
		protected User SUT;

		[TestInitialize]
		public void Setup()
		{
			IdGenerator.PrepareGeneratorForTest(0);
		}

		[TestMethod]
		public void WhenCreateUser_ThenVerifySUT()
		{
			SUT = new User("some user");
			Approvals.Verify(SUT.ToPrettyString());
		}
	}
}
