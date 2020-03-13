using System;
using System.Collections.Generic;

namespace SoftAssert
{
	public abstract class BaseAssert<T>: IAssertable where T: Enum
	{
		public string Message { get; protected set; }

		public T AssertType { get; protected set; }
				
		public BaseAssert(T assertType, string message = null)
		{
			AssertType = assertType;
			Message = message;
		}

		public string GetAssertType()
		{
			return AssertType.ToString();
		}

		/// <summary>
		/// This method throws an instance of <see cref="UnexpectedEnumValueException{T}"> class if <see cref="Assert"/>
		/// method will receive invalid enum value as <see cref="AssertType"/> which must be an element of Enum which is used by 
		/// one of childrens of class <see cref="BaseAssert{T}"/>
		/// </summary>
		protected void ThrowExceptionIfInvalidEnumItem()
		{
			throw new UnexpectedEnumValueException<T>(AssertType);
		}

		public abstract void Assert();

		public abstract IEnumerable<object> GetAssertParams();
	}
}
