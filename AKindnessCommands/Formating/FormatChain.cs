using System.Collections.Generic;

namespace AKindnessCommands.Formating
{
	/// <summary>
	/// This format will apply all its subformat in a srict order on the input. Use to combine more then one format.
	/// </summary>
	/// <typeparam name="TIn">The inputtype of the first subformat.</typeparam>
	/// <typeparam name="TOut">The outputtype of the last subformat.</typeparam>
	public sealed
	class FormatChain<TIn,TOut>
	: Format<TIn,TOut>
	{
		List< IUnsafeFormat > formats = new List< IUnsafeFormat >( );

		public override
		TOut Apply( TIn input )
		{
			object _current = input;
			foreach ( var _format in formats )
			{
				_current = _format.Apply( _current );
			}
			return ( TOut )_current;
		}
	}
}