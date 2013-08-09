using System.Collections.Generic;
using AKindnessCommands.Formating.Container;

namespace AKindnessCommands.Formating.Flow
{
	public static
	class ConcatedFlow
	{
		public static
		Concated< TValue, TDelimiter > Concated< TValue, TDelimiter >(
			this FlowConnector< IEnumerable< TValue > > input, TDelimiter delimiter )
		{
			return new Concated< TValue, TDelimiter >( new List< TValue >( input.Value ), delimiter );
		}

		public static
		Concated< TValue, string > Concated< TValue >(
			this FlowConnector< IEnumerable< TValue > > input, string delimiter = "" )
		{
			return new Concated< TValue, string >( new List< TValue >( input.Value ), delimiter );
		}

		public static
		Concated< TValue, TDelimiter > Concated< TValue, TDelimiter >(
			this FlowConnector< TValue[ ] > input, TDelimiter delimiter )
		{
			return new Concated< TValue, TDelimiter >( new List< TValue >( input.Value ), delimiter );
		}

		public static
		Concated< TValue, string > Concated< TValue >(
			this FlowConnector< TValue[ ] > input, string delimiter = "" )
		{
			return new Concated< TValue, string >( new List< TValue >( input.Value ), delimiter );
		}
	}
}