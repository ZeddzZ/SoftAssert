using SoftAssert.Asserts;
using SoftAssert.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SoftAssert
{
	public abstract class TwoParamsAssert<T1, T2> : BaseAssert<TwoParamsAssertTypes>
	{
		public T1 FirstParam { get; protected set; }
		public T2 SecondParam { get; protected set; }

		public TwoParamsAssert(TwoParamsAssertTypes assertType, T1 firstParam, T2 secondParam,  string message = null) : base(assertType, message)
		{
			FirstParam = firstParam;
			SecondParam = secondParam;
		}

		public override void Assert()
		{
			switch (AssertType)
			{
				case TwoParamsAssertTypes.AreEqual:
					AreEqual(FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.AreNotEqual:
					AreNotEqual(FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.AreSame:
					AreSame(FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.AreNotSame:
					AreNotSame(FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.Contains:
					AssertionHelper.ExecuteIfAppropriateType<object, ICollection, T1, T2>(Contains, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.NotContains:
					AssertionHelper.ExecuteIfAppropriateType<object, ICollection, T1, T2>(NotContains, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.Greater:
					AssertionHelper.ExecuteIfAppropriateType<IComparable, IComparable, T1, T2>(Greater, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.GreaterOrEqual:
					AssertionHelper.ExecuteIfAppropriateType<IComparable, IComparable, T1, T2>(GreaterOrEqual, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.Less:
					AssertionHelper.ExecuteIfAppropriateType<IComparable, IComparable, T1, T2>(Less, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.LessOrEqual:
					AssertionHelper.ExecuteIfAppropriateType<IComparable, IComparable, T1, T2>(LessOrEqual, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.IsAssignableFrom:
					AssertionHelper.ExecuteIfAppropriateType<Type, object, T1, T2>(IsAssignableFrom, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.IsNotAssignableFrom:
					AssertionHelper.ExecuteIfAppropriateType<Type, object, T1, T2>(IsNotAssignableFrom, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.IsInstanceOf:
					AssertionHelper.ExecuteIfAppropriateType<Type, object, T1, T2>(IsInstanceOf, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.IsNotInstanceOf:
					AssertionHelper.ExecuteIfAppropriateType<Type, object, T1, T2>(IsNotInstanceOf, FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.That:
					That(FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.Throws:
					Throws(FirstParam, SecondParam, Message);
					break;
				case TwoParamsAssertTypes.ThrowsAsync:
					ThrowsAsync(FirstParam, SecondParam, Message);
					break;
				default:
					ThrowExceptionIfInvalidEnumItem();
					break;
			}
		}

		public override IEnumerable<object> GetAssertParams()
		{
			return new List<object> { FirstParam, SecondParam };
		}

		/// <summary>
		/// Checks if first param is equal to second param
		/// </summary>
		/// <param name="firstParam">The value that is expected</param>
		/// <param name="secondParam">The actual value</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void AreEqual(object firstParam, object secondParam, string message = null);

		/// <summary>
		/// Checks if first param is not equal to second param
		/// </summary>
		/// <param name="firstParam">The value that is expected</param>
		/// <param name="secondParam">The actual value</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void AreNotEqual(object firstParam, object secondParam, string message = null);

		/// <summary>
		/// Checks if first param is the same as second param
		/// </summary>
		/// <param name="firstParam">The value that is expected</param>
		/// <param name="secondParam">The actual value</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void AreSame(object firstParam, object secondParam, string message = null);

		/// <summary>
		/// Checks if first param is not the same second param
		/// </summary>
		/// <param name="firstParam">The value that is expected</param>
		/// <param name="secondParam">The actual value</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void AreNotSame(object firstParam, object secondParam, string message = null);

		/// <summary>
		/// Checks if second param (collection) contains first param
		/// </summary>
		/// <param name="firstParam">The value that should be in collection</param>
		/// <param name="secondParam">The collection which should contain first param</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void Contains(object firstParam, ICollection secondParam, string message = null);

		/// <summary>
		/// Checks if second param (collection) not contains first param
		/// </summary>
		/// <param name="firstParam">The value that should not be in collection</param>
		/// <param name="secondParam">The collection which should not contain first param</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void NotContains(object firstParam, ICollection secondParam, string message = null);

		/// <summary>
		/// Checks if first param is greater than second param
		///  
		/// <param name="firstParam">IComparable instance that should be greater</param>
		/// <param name="secondParam">IComparable instance that should be less</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void Greater(IComparable firstParam, IComparable secondParam, string message = null);

		/// <summary>
		/// Checks if first param is greater or equal than second param
		///  
		/// <param name="firstParam">IComparable instance that should be greater</param>
		/// <param name="secondParam">IComparable instance that should be less</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void GreaterOrEqual(IComparable firstParam, IComparable secondParam, string message = null);

		/// <summary>
		/// Checks if first param is less than second param
		///  
		/// <param name="firstParam">IComparable instance that should be less</param>
		/// <param name="secondParam">IComparable instance that should be greater</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void Less(IComparable firstParam, IComparable secondParam, string message = null);

		/// <summary>
		/// Checks if first param is less or equal than second param
		///  
		/// <param name="firstParam">IComparable instance that should be less or equal</param>
		/// <param name="secondParam">IComparable instance that should be greater or equal</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void LessOrEqual(IComparable firstParam, IComparable secondParam, string message = null);

		/// <summary>
		/// Checks if second param may be assigned a value of first param Type
		///  
		/// <param name="firstParam">The expected Type</param>
		/// <param name="secondParam">The object under examination</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsAssignableFrom(Type firstParam, object secondParam, string message = null);

		/// <summary>
		/// Checks if second param may not be assigned a value of first param Type
		///  
		/// <param name="firstParam">The expected Type</param>
		/// <param name="secondParam">The object under examination</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsNotAssignableFrom(Type firstParam, object secondParam, string message = null);

		/// <summary>
		/// Checks if second param is an instance of first param Type
		///  
		/// <param name="firstParam">The expected Type</param>
		/// <param name="secondParam">The object under examination</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsInstanceOf(Type firstParam, object secondParam, string message = null);

		/// <summary>
		/// Checks if second param is not an instance of first param Type
		///  
		/// <param name="firstParam">The expected Type</param>
		/// <param name="secondParam">The object under examination</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsNotInstanceOf(Type firstParam, object secondParam, string message = null);

		/// <summary>
		/// Checks that first param meet requirements of second param
		/// WARNING: No validations were made for method params here because of a lot of different possible arguments
		/// Be sure you made all necessary validations while implementing this method
		/// </summary>
		/// <param name="firstParam">The object under examination</param>
		/// <param name="secondParam">Requirements that shoulld be met by firstParam</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void That(T1 firstParam, T2 secondParam, string message = null);

		/// <summary>
		///  Verifies that a delegate throws a particular exception when called.
		/// WARNING: No validations were made for method params here because of a lot of different possible arguments
		/// Be sure you made all necessary validations while implementing this method
		/// </summary>
		/// <param name="firstParam"> A The exception Type expected (of type NUnit.Framework.TestDelegate)</param>
		/// <param name="firstParam"> A TestDelegate (of type NUnit.Framework.TestDelegate)</param>
		/// <param name="message">The message that will be displayed on failure</param>
		/// <returns>Thrown exception</returns>
		public abstract Exception Throws(T1 firstParam, T2 secondParam, string message = null);

		/// <summary>
		///  Verifies that a delegate throws a particular exception when called.
		/// WARNING: No validations were made for method params here because of a lot of different possible arguments
		/// Be sure you made all necessary validations while implementing this method
		/// </summary>
		/// <param name="firstParam"> A The exception Type expected (of type NUnit.Framework.TestDelegate)</param>
		/// <param name="firstParam"> A TestDelegate (of type NUnit.Framework.TestDelegate)</param>
		/// <param name="message">The message that will be displayed on failure</param>
		/// <returns>Thrown exception</returns>
		public abstract Exception ThrowsAsync(T1 firstParam, T2 secondParam, string message = null);
	}
}
