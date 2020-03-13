
using SoftAssert.Enums;
using System.Collections.Generic;

namespace SoftAssert
{
	public abstract class TwoParamsWithDeltaAssert : BaseAssert<TwoParamsAssertWithDeltaTypes>
	{
		public double FirstParam { get; protected set; }
		public double SecondParam { get; protected set; }
		public double Delta { get; protected set; }

		public TwoParamsWithDeltaAssert(TwoParamsAssertWithDeltaTypes assertType, double firstParam, double secondParam, double delta, string message = null) : base(assertType, message)
		{
			FirstParam = firstParam;
			SecondParam = secondParam;
			Delta = delta;
		}

		public override void Assert()
		{
			switch (AssertType)
			{
				case TwoParamsAssertWithDeltaTypes.AreEqual:
					AreEqual(FirstParam, SecondParam, Delta, Message);
					break;
				default:
					ThrowExceptionIfInvalidEnumItem();
					break;
			}
		}

		public override IEnumerable<object> GetAssertParams()
		{
			return new List<object> { FirstParam, SecondParam, Delta };
		}

		/// <summary>
		/// Checks if first param is equal to second param
		/// </summary>
		/// <param name="firstParam">The value that is expected</param>
		/// <param name="secondParam">The actual value</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void AreEqual(double firstParam, double secondParam, double delta, string message = null);

	}
}
