using SoftAssert.Asserts;
using SoftAssert.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SoftAssert
{
	public abstract class OneParamAssert<T> : BaseAssert<OneParamAssertTypes>
	{
		public T FirstParam { get; protected set; }

		public OneParamAssert(OneParamAssertTypes assertType, T firstParam, string message = null) : base(assertType, message)
		{
			FirstParam = firstParam;
		}

		public override void Assert()
		{
			switch (AssertType)
			{
				case OneParamAssertTypes.IsTrue:
					AssertionHelper.ExecuteIfBool(IsTrue, FirstParam, Message);
					break;
				case OneParamAssertTypes.IsFalse:
					AssertionHelper.ExecuteIfBool(IsFalse, FirstParam, Message);
					break;
				case OneParamAssertTypes.IsEmpty:
					AssertionHelper.ExecuteIfAppropriateType<T, ICollection>(IsEmpty, FirstParam, Message);
					break;
				case OneParamAssertTypes.IsNotEmpty:
					AssertionHelper.ExecuteIfAppropriateType<T, ICollection>(IsNotEmpty, FirstParam, Message);
					break;
				case OneParamAssertTypes.IsNull:
					IsNull(FirstParam, Message);
					break;
				case OneParamAssertTypes.IsNotNull:
					IsNotNull(FirstParam, Message);
					break;
				case OneParamAssertTypes.IsZero:
					AssertionHelper.ExecuteIfNumeric(IsZero, FirstParam, Message);
					break;
				case OneParamAssertTypes.IsNotZero:
					AssertionHelper.ExecuteIfNumeric(IsNotZero, FirstParam, Message);
					break;
				case OneParamAssertTypes.IsPositive:
					AssertionHelper.ExecuteIfNumeric(IsPositive, FirstParam, Message);
					break;
				case OneParamAssertTypes.IsNegative:
					AssertionHelper.ExecuteIfNumeric(IsNegative, FirstParam, Message);
					break;
				case OneParamAssertTypes.That:
					var wasAsserted1 = AssertionHelper.ExecuteIfBool(That, FirstParam, Message, false);
					var wasAsserted2 = AssertionHelper.ExecuteIfAppropriateType<T, Func<bool>>(That, FirstParam, Message, false);
					if (!(wasAsserted1 || wasAsserted2))
					{
						AssertionHelper.ThrowExceptionIfNeeded(true, typeof(bool), FirstParam.GetType());
					}
					break;
				case OneParamAssertTypes.Throws:
					Throws(FirstParam, Message);
					break;
				case OneParamAssertTypes.ThrowsAsync:
					ThrowsAsync(FirstParam, Message);
					break;
				default:
					ThrowExceptionIfInvalidEnumItem();
					break;
			}
		}

		public override IEnumerable<object> GetAssertParams()
		{
			return new List<object>{ FirstParam };
		}

		/// <summary>
		/// Checks if received boolean is true
		/// </summary>
		/// <param name="condition">Boolean that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsTrue(bool condition, string message = null);

		/// <summary>
		/// Checks if received boolean is false
		/// </summary>
		/// <param name="condition">Boolean that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsFalse(bool condition, string message = null);

		/// <summary>
		/// Checks if received collection is empty
		/// </summary>
		/// <param name="collection">Collection that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsEmpty(ICollection collection, string message = null);

		/// <summary>
		/// Checks if received collection is not empty
		/// </summary>
		/// <param name="collection">Collection that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsNotEmpty(ICollection collection, string message = null);

		/// <summary>
		/// Checks if received object is null
		/// </summary>
		/// <param name="anObject">Object that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsNull(object anObject, string message = null);

		/// <summary>
		/// Checks if received object is not null
		/// </summary>
		/// <param name="anObject">Object that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsNotNull(object anObject, string message = null);
		
		/// <summary>
		/// Checks if received numeric is equals to zero
		/// 
		/// Overriding this method you can be sure that T is one of numeric types because it will be called
		/// only after check that T is one of numeric types (int, uint, long, ulong, double, float, short, byte decimal)
		/// </summary>
		/// <param name="numeric">Instance of numeric that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsZero(T numeric, string message = null);
		
		/// <summary>
		/// Checks if received numeric is not equals to zero
		/// 
		/// Overriding this method you can be sure that T is one of numeric types because it will be called
		/// only after check that T is one of numeric types (int, uint, long, ulong, double, float, short, byte decimal)
		/// </summary>
		/// <param name="numeric">Instance of numeric that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsNotZero(T numeric, string message = null);
		
		/// <summary>
		/// Checks if received numeric is greater than zero
		/// 
		/// Overriding this method you can be sure that T is one of numeric types because it will be called
		/// only after check that T is one of numeric types (int, uint, long, ulong, double, float, short, byte decimal)
		/// </summary>
		/// <param name="numeric">Instance of numeric that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsPositive(T numeric, string message = null);
		
		/// <summary>
		/// Checks if received numeric is less than zero
		/// 
		/// Overriding this method you can be sure that T is one of numeric types because it will be called
		/// only after check that T is one of numeric types (int, uint, long, ulong, double, float, short, byte decimal)
		/// </summary>
		/// <param name="numeric">Instance of numeric that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void IsNegative(T numeric, string message = null);
		
		/// <summary>
		/// Checks if condition is true
		/// </summary>
		/// <param name="condition">Boolean that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void That(bool condition, string message = null);

		/// <summary>
		/// Checks if condition is true
		/// </summary>
		/// <param name="condition">Boolean that should be checked</param>
		/// <param name="message">Additional message that will be written if assertion fails</param>
		public abstract void That(Func<bool> condition, string message = null);

		/// <summary>
		///  Verifies that a delegate throws a particular exception when called.
		/// </summary>
		/// <param name="code"> A TestDelegate (of type NUnit.Framework.TestDelegate)</param>
		/// <param name="message">The message that will be displayed on failure</param>
		/// <returns>Thrown exception</returns>
		public abstract Exception Throws(T code, string message = null);
		
		/// <summary>
		///  Verifies that a delegate throws a particular exception when called.
		/// </summary>
		/// <param name="code"> A TestDelegate (of type NUnit.Framework.TestDelegate)</param>
		/// <param name="message">The message that will be displayed on failure</param>
		/// <returns>Thrown exception</returns>
		public abstract Exception ThrowsAsync(T code, string message = null);
	}
}
