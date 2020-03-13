using SoftAssert.Enums;
using System.Collections.Generic;

namespace SoftAssert
{
	public abstract class ZeroParamsAssert : BaseAssert<ZeroParamAssertTypes>
	{
		public ZeroParamsAssert(ZeroParamAssertTypes assertType, string message = null) : base(assertType, message) { }

		public override void Assert()
		{
			switch (AssertType)
			{
				case ZeroParamAssertTypes.Fail:
					Fail(Message);
					break;
				case ZeroParamAssertTypes.Ignore:
					Ignore(Message);
					break;
				case ZeroParamAssertTypes.Inconclusive:
					Inconclusive(Message);
					break;
				case ZeroParamAssertTypes.Pass:
					Pass(Message);
					break;
				default:
					ThrowExceptionIfInvalidEnumItem();
					break;
			}
		}

		public override IEnumerable<object> GetAssertParams()
		{
			return new List<object>();
		}

		/// <summary>
		/// Fails current assert
		/// </summary>
		/// <param name="message">Additional message that will be written by thrown exception</param>
		public abstract void Fail(string message = null);

		/// <summary>
		/// Sets status of current test to ignored
		/// </summary>
		/// <param name="message">Additional message that will be written by thrown exception</param>
		public abstract void Ignore(string message = null);

		/// <summary>
		/// Sets status of current test to inconclusive
		/// </summary>
		/// <param name="message">Additional message that will be written by thrown exception</param>
		public abstract void Inconclusive(string message = null);

		/// <summary>
		/// Sets status of current test to passed
		/// </summary>
		/// <param name="message">Additional message that will be written by thrown exception</param>
		public abstract void Pass(string message = null);
	}
}
