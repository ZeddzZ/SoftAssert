using SoftAssert;
using SoftAssert.Enums;
using assert = NUnit.Framework.Assert;

namespace NunitSoftAssert
{
	class NunitZeroParamsAssert : ZeroParamsAssert
	{
		public NunitZeroParamsAssert(ZeroParamAssertTypes assertType, string message = null) 
			: base(assertType, message) { }
		public override void Fail(string message = null)
		{
			assert.Fail(message);
		}

		public override void Ignore(string message = null)
		{
			assert.Fail(message);
		}

		public override void Inconclusive(string message = null)
		{
			assert.Fail(message);
		}

		public override void Pass(string message = null)
		{
			assert.Pass(message);
		}
	}
}
