using System;
using System.Collections.Generic;
using System.Text;

namespace SoftAssert
{
	public class WrongArgumentTypeException : ArgumentException
	{
		private const string DEFAULT_MESSAGE = "Argument of wrong type received. Expected {0}, but was {1}!";
		private const string EXTENDED_MESSAGE = DEFAULT_MESSAGE + "\r\nAdditional message: {2}";
		public WrongArgumentTypeException(Type expectedType, Type actualType) : base(string.Format(DEFAULT_MESSAGE, expectedType, actualType)) { }
		public WrongArgumentTypeException(string message) : base(message) { }
		public WrongArgumentTypeException(Type expectedType, Type actualType, string additionalMessage) : base(string.Format(EXTENDED_MESSAGE, expectedType, actualType, additionalMessage)) { }
	}
}
