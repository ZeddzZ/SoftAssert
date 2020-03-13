using SoftAssert;
using SoftAssert.Enums;

namespace SoftAssertTests.AssertStubs
{
	/// <summary>
	/// This class is an implemaantation of abstract class <see cref="ZeroParamAssert"/> 
	/// created only for testing purposes and has only stubs for abstract methods.
	/// Don't use it anywhere else.
	/// </summary>
	internal class ZeroParamAssertStub : ZeroParamAssert
	{
		public ZeroParamAssertStub(ZeroParamAssertTypes type, string message = null) : base(type, message) { }
		public override void AssertFail(string message = null)
		{
			throw new System.NotImplementedException();
		}

		public override void AssertIgnore(string message = null)
		{
			throw new System.NotImplementedException();
		}

		public override void Assertinconclusive(string message = null)
		{
			throw new System.NotImplementedException();
		}

		public override void AssertPass(string message = null)
		{
			throw new System.NotImplementedException();
		}
	}
}
