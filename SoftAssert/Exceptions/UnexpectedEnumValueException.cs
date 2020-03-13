using System;

namespace SoftAssert
{
	class UnexpectedEnumValueException<T> : ArgumentException
	{
		private const string DEFAULT_MESSAGE = "Value {0} of enum {1} is not supported!";
		private const string EXTENDED_MESSAGE = DEFAULT_MESSAGE + "\r\nAdditional message: {2}";
		public UnexpectedEnumValueException(T value): base(string.Format(DEFAULT_MESSAGE, value, typeof(T).Name)) { }
		public UnexpectedEnumValueException(string message) : base(message) { }
		public UnexpectedEnumValueException(T value, string additionalMessage) : base(string.Format(EXTENDED_MESSAGE, value, typeof(T).Name, additionalMessage)) { }
	}
}
