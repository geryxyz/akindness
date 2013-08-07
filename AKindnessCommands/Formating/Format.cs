namespace AKindnessCommands.Formating
{
	/// <summary>
	/// Baseclass for all formats. Use this to implement your own format.
	/// </summary>
	/// <typeparam name="TIn">Input type.</typeparam>
	/// <typeparam name="TOut">Output type.</typeparam>
	public abstract
	class Format< TIn,TOut >
	: IUnsafeFormat 
	{
		public abstract
		TOut Apply( TIn input );

		public
		object Apply( object input )
		{
			return Apply( ( TIn )input );
		}
	}
}