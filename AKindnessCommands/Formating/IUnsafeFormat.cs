namespace AKindnessCommands.Formating
{
	/// <summary>
	/// Base, typeless interface of formats. Use to create typeless format collections.
	/// </summary>
	public
	interface IUnsafeFormat
	{
		object Apply( object input );
	}
}