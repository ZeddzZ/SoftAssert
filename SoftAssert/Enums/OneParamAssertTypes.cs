namespace SoftAssert.Enums
{
	public enum OneParamAssertTypes
	{
		/// <summary>
		/// Takes bool condition
		/// </summary>
		IsTrue,
		/// <summary>
		/// Takes bool condition
		/// </summary>
		IsFalse,
		/// <summary>
		/// Takes collection or string
		/// </summary>
		IsEmpty,
		/// <summary>
		/// Takes collection or string
		/// </summary>
		IsNotEmpty,
		/// <summary>
		/// Takes any object
		/// </summary>
		IsNull,
		/// <summary>
		/// Takes any object
		/// </summary>
		IsNotNull,
		/// <summary>
		/// Takes any numeric value
		/// </summary>
		IsZero,
		/// <summary>
		/// Takes any numeric value
		/// </summary>
		IsNotZero,
		/// <summary>
		/// Takes any numeric value
		/// </summary>
		IsPositive,
		/// <summary>
		/// Takes any numeric value
		/// </summary>
		IsNegative,
		/// <summary>
		/// Takes a boolean condition
		/// </summary>
		That,
		/// <summary>
		/// Takes Test Delegate as param
		/// </summary>
		Throws,
		/// <summary>
		/// Takes Test Delegate as param
		/// </summary>
		ThrowsAsync,
	}
}
