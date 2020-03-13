using System;
using System.ComponentModel;

namespace SoftAssert.Asserts
{
	public static class AssertionHelper
	{
		public static bool ExecuteIfBool<T>(Action<bool, string> assert, T param, string message, bool isExceptionThrown = true)
		{
			switch (param)
			{
				case bool boolParam:
					assert(boolParam, message);
					return true;
				default:
					ThrowExceptionIfNeeded(isExceptionThrown, typeof(bool), param.GetType());
					return false;
			}
			/*Type paramType = param.GetType();
			if (paramType == typeof(bool))
			{
				assert(Convert.ToBoolean(param), message);
				return true;
			}
			else
			{
				ThrowExceptionIfNeeded(isExceptionThrown, typeof(bool), paramType);
				return false;
			}*/
		}

		public static bool ExecuteIfAppropriateType<T0, T1>(Action<T1, string> assert, T0 param, string message, bool isExceptionThrown = true)
		{
			switch (param)
			{
				case T1 genericParam:
					assert(genericParam, message);
					return true;
				default:
					ThrowExceptionIfNeeded(isExceptionThrown, typeof(T1), param.GetType());
					return false;
			}
			/*Type paramType = param.GetType();
			if (paramType == typeof(T1))
			{
				assert(ConvertToGeneric<T1>(param), message);
				return true;
			}
			else
			{
				ThrowExceptionIfNeeded(isExceptionThrown, typeof(T1), paramType);
				return false;
			}*/
		}

		public static bool ExecuteIfNumeric<T>(Action<T, string> assert, T param, string message, bool isExceptionThrown = true)
		{
			if (IsNumeric(param))
			{
				assert(param, message);
				return true;
			}
			else
			{
				ThrowExceptionIfNeeded(isExceptionThrown, typeof(ValueType), param.GetType());
				return false;
			}
		}

		public static bool ExecuteIfNumeric<T1, T2>(Action<T1, T2, string> assert, T1 firstParam, T2 secondParam, string message, bool isExceptionThrown = true)
		{
			Type firstParamType = firstParam.GetType();
			Type secondParamType = secondParam.GetType();

			if (!IsNumeric(firstParam))
			{
				ThrowExceptionIfNeeded(isExceptionThrown, typeof(ValueType), firstParamType);
				return false;
			} 
			else if (!IsNumeric(secondParam))
			{
				ThrowExceptionIfNeeded(isExceptionThrown, typeof(ValueType), secondParamType);
				return false;
			} 
			else if (firstParamType != secondParamType)
			{
				ThrowExceptionIfNeeded(isExceptionThrown, typeof(T1), secondParamType);
				return false;
			}
			else
			{
				assert(firstParam, secondParam, message);
				return true;
			}
		}

		public static bool ExecuteIfSameType<T1, T2>(Action<T1, T1, string> assert, T1 firstParam, T2 secondParam, string message, bool isExceptionThrown = true)
		{
			Type firstParamType = firstParam.GetType();
			Type secondParamType = secondParam.GetType();
			if (firstParamType == secondParamType)
			{
				assert(ConvertToGeneric<T1>(firstParam), ConvertToGeneric<T1>(secondParam), message);
				return true;
			}
			else
			{
				ThrowExceptionIfNeeded(isExceptionThrown, typeof(T1), secondParamType);
				return false;
			}
		}

		public static bool ExecuteIfAppropriateType<T1, T2, T3, T4>(Action<T1, T2, string> assert, T3 firstParam, T4 secondParam, string message, bool isExceptionThrown = true)
		{
			Type firstParamType = firstParam.GetType();
			Type secondParamType = secondParam.GetType();

			if (firstParamType != typeof(T1))
			{
				ThrowExceptionIfNeeded(isExceptionThrown, typeof(T1), firstParamType);
				return false;
			} 
			else if (secondParamType != typeof(T2))
			{
				ThrowExceptionIfNeeded(isExceptionThrown, typeof(T2), secondParamType);
				return false;
			}
			else
			{
				assert(ConvertToGeneric<T1>(firstParam), ConvertToGeneric<T2>(secondParam), message);
				return true;
			}
		}

		/// <summary>
		/// Checks if param is one of numeric types
		/// (int, uint, long, ulong, double, float, short, byte decimal)
		/// </summary>
		/// <param name="paramType">type we need to check</param>
		/// <returns>True if type is one of numeric types</returns>
		/*public static bool IsNumeric(Type paramType)
		{
			return paramType == typeof(int)
				|| paramType == typeof(uint)
				|| paramType == typeof(double)
				|| paramType == typeof(long)
				|| paramType == typeof(ulong)
				|| paramType == typeof(float)
				|| paramType == typeof(decimal)
				|| paramType == typeof(short)
				|| paramType == typeof(byte);
		}*/

		/// <summary>
		/// Checks if param is one of numeric types
		/// (int, uint, long, ulong, double, float, short, byte decimal)
		/// </summary>
		/// <typeparam name="T">Type of param, could be anything</typeparam>
		/// <param name="param">param which type we need to check</param>
		/// <returns>True if param has one of numeric types (equals to T is one of numeric types)</returns>
		public static bool IsNumeric<T>(T param)
		{
			switch (param)
			{
				case int intParam:
				case uint uintParam:
				case double doubleParam:
				case long longParam:
				case ulong ulongParam:
				case float floatParam:
				case decimal decimalParam:
				case short shortParam:
				case byte byteParam:				
					return true;
				default:
					return false;
			}

			/*Type paramType = param.GetType();

			return IsNumeric(paramType);*/
		}

		public static T ConvertToGeneric<T>(object initialValue)
		{
			return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(initialValue);
		}
		/// <summary>
		/// if isExceptionThrown is true, throws new instance of <see cref="WrongArgumentTypeException"/>
		/// with expected and actual types as arguments
		/// If false, just do nothing
		/// </summary>
		/// <param name="isExceptionThrown">boolean value, if true, exception will be thrown, else do nothing</param>
		/// <param name="expected">Type that was expected to be</param>
		/// <param name="actual">Actual type that was received</param>
		internal static void ThrowExceptionIfNeeded(bool isExceptionThrown, Type expected, Type actual)
		{
			if (isExceptionThrown)
			{
				throw new WrongArgumentTypeException(expected, actual);
			}
		}
	}
}
