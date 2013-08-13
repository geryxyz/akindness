using System.Collections;
using System.Collections.Generic;
using AKindnessCommands.Formating.Container;
using System.Linq;

namespace AKindnessCommands.Formating.Flow
{
	public static
	class AppendFlow
	{
		public static
		Concated<object , string> Append<TValue, TNew>(this FlowConnector<TValue> input, TNew appende )
		{
			IEnumerable< object > _in;
			if ( input.Value is IEnumerable )
			{
				_in = ( ( IEnumerable )input.Value ).Cast< object >( );
			}
			else
			{
				_in = new object[ ] { input.Value };
			}
			IEnumerable< object > _appende;
			if ( appende is IEnumerable )
			{
				_appende = ( ( IEnumerable )appende ).Cast< object >( );
			}
			else
			{
				_appende = new object[ ] { appende };
			}

			return
				new Concated< object, string >(
					new List< object >( _in.Concat( _appende ) ), string.Empty );
		}
	}
}