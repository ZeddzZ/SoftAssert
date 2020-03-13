using NUnit.Framework;
using SoftAssert.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public static class TestCaseDataGenerator
{
	private static readonly List<Type> listOfEnumsWithArgumentsAmount = new List<Type>
		{
			typeof(ZeroParamAssertTypes),
			typeof(OneParamAssertTypes),
			typeof(TwoParamsAssertTypes),
			typeof(TwoParamsAssertWithDeltaTypes),
		};

	private static readonly List<List<object>> zeroParams = new List<List<object>>
		{
			new List<object>(),
		};

	private static readonly List<List<object>> singleParams = new List<List<object>>
		{
			new List<object> { true },
			new List<object> { 15 },
			new List<object> { 2.28 },
			new List<object> { 3.14f },
			new List<object> { new DateTime(2020, 1, 1) },
			new List<object> { "abc" },
			new List<object> { 's' },
			new List<object> { new object() },
			new List<object> { null },
		};

	private static readonly List<List<object>> doubleParams = new List<List<object>>
		{
			new List<object> { 15, 25 },
			new List<object> { 2.28, 1.5f },
			new List<object> { 3.14f, 6m },
			new List<object> { "abc", "cba" },
			new List<object> { 's', 'q' },
			new List<object> { new object(), new object() },
			new List<object> { null, null },
			new List<object> { "a.c", "cb.a" },
			new List<object> { "a.c aa", "cb.a b-b" },
			new List<object> { new DateTime(2020, 1, 1), new DateTime(2020, 1, 2)},
		};

	private static readonly List<List<object>> tripleParams = new List<List<object>>
		{
			new List<object> { 1, 2, 0 },
			new List<object> { 1, 2, 1 },
			new List<object> { 2.2, 2d, .5 },
			new List<object> { 2.2, 2d, 0 },
		};

	public static IEnumerable<TestCaseData> GetAssertParams()
	{
		List<TestCaseData> returnData = new List<TestCaseData>();
		foreach (var e in listOfEnumsWithArgumentsAmount)
		{
			Array enumFields = Enum.GetValues(e);
			foreach (var enumField in enumFields)
			{
				foreach (var arguments in GetListOfArguments((Enum)enumField))
				{
					var testCaseData = new TestCaseData(enumField, arguments);
					testCaseData.SetArgDisplayNames(FormatTestArguments(enumField, arguments));
					returnData.Add(testCaseData);
				}
			}
		}
		foreach (var returnedTestCaseData in returnData)
		{
			yield return returnedTestCaseData;
		}
	}

	private static string FormatTestArguments(params object[] arguments)
	{
		StringBuilder sb = new StringBuilder();
		foreach (var arg in arguments)
		{
			if (arg is IEnumerable)
			{
				sb.Append("{ ");
				foreach (var a in arg as IEnumerable)
				{
					//sb.Append(a);
					if (a == null)
					{
						sb.Append(FormatArgumentName("null"));
					}
					else
					{
						sb.Append(FormatArgumentName(a));
					}
				}
				sb.Append("}, ");
			}
			else
			{
				sb.Append(FormatArgumentName(arg));
			}
		}
		string line = sb.ToString().Trim();
		line = line.Remove(line.LastIndexOf(','), 1);
		line = line.Remove(line.LastIndexOf(','), 1);
		return line;
	}

	private static string FormatArgumentName(object arg)
	{
		if (arg.GetType() == typeof(string))
		{
			return $"\"{arg}\", ";
		}
		if (arg.GetType() == typeof(char))
		{
			return $"'{arg}', ";
		}
		return $"{arg}, ";
	}

	private static List<List<object>> GetListOfArguments(Enum enumItem)
	{
		switch (enumItem)
		{
			case OneParamAssertTypes oneParam:
				return singleParams;
			case TwoParamsAssertTypes twoParams:
				return doubleParams;
			case TwoParamsAssertWithDeltaTypes twoParamsWithDelta:
				return tripleParams;
			case ZeroParamAssertTypes noParams:
			default:
				return zeroParams;
		}
	}
}