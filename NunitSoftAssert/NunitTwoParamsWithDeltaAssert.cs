using SoftAssert;
using SoftAssert.Enums;
using assert = NUnit.Framework.Assert;

namespace NunitSoftAssert
{
    public class NunitTwoParamsWithDeltaAssert : TwoParamsWithDeltaAssert
    {
        public NunitTwoParamsWithDeltaAssert(TwoParamsAssertWithDeltaTypes assertType, double firstParam, double secondParam, double delta, string message = null) 
            : base(assertType, firstParam, secondParam, delta, message) { }

        public override void AreEqual(double firstParam, double secondParam, double delta, string message = null)
        {
            assert.AreEqual(firstParam, secondParam, delta, message);
        }
    }
}
