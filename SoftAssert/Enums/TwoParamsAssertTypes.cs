namespace SoftAssert.Enums
{
	public enum TwoParamsAssertTypes
	{
		/// <summary>
		/// Takes two objects as params
		/// </summary>
		AreEqual,
		/// <summary>
		/// Takes two objects as params
		/// </summary>
		AreNotEqual,
		/// <summary>
		/// Takes two objects as params
		/// </summary>
		AreSame,
		/// <summary>
		/// Takes two objects as params
		/// </summary>
		AreNotSame,
		/// <summary>
		/// Takes object and ICollection as params
		/// </summary>
		Contains,
		/// <summary>
		/// Takes object and ICollection as params
		/// </summary>
		NotContains,
		/// <summary>
		/// Takes two numerics as params
		/// </summary>
		Greater,
		/// <summary>
		/// Takes two numerics as params
		/// </summary>
		GreaterOrEqual,
		/// <summary>
		/// Takes two numerics as params
		/// </summary>
		Less,
		/// <summary>
		/// Takes two numerics as params
		/// </summary>
		LessOrEqual,
		/// <summary>
		/// Takes object and Type as params
		/// </summary>
		IsAssignableFrom,
		/// <summary>
		/// Takes object and Type as params
		/// </summary>
		IsNotAssignableFrom,
		/// <summary>
		/// Takes object and Type as params
		/// </summary>
		IsInstanceOf,
		/// <summary>
		/// Takes object and Type as params
		/// </summary>
		IsNotInstanceOf,
		/// <summary>
		/// Takes various types  as params
		/// </summary>
		That,
		/// <summary>
		/// Takes various types as params
		/// </summary>
		Throws,
		/// <summary>
		/// Takes various types as params
		/// </summary>
		ThrowsAsync,
	}
}
