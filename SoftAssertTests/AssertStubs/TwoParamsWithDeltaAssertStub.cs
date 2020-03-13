using SoftAssert;
using SoftAssert.Enums;
using System;
namespace SoftAssertTests.AssertStubs
{
	/// <summary>
	/// This class is an implemaantation of abstract class <see cref="TwoParamsWithDeltaAssert"/> 
	/// created only for testing purposes and has only stubs for abstract methods.
	/// Don't use it anywhere else.
	/// </summary>
	internal class TwoParamsWithDeltaAssertStub : TwoParamsWithDeltaAssert
	{
		public TwoParamsWithDeltaAssertStub(TwoParamsAssertWithDeltaTypes type, double firstParam, double secondParam, double delta, string message = null) : base(type, firstParam, secondParam, delta, message) { }

		public override void AreEqual(double firstParam, double secondParam, double delta, string message = null)
		{
			throw new NotImplementedException();
		}
	}
}
