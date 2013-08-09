using System.Collections.Generic;
using System.Linq;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Formating.Container
{
	public
	class Concated<TValue,TDelimiter>
	: ConcurrentWriteable
	{
		List< TValue > content;

		public
		TDelimiter Delimiter { get; private set; }

		public
		Concated( List< TValue > content, TDelimiter delimiter )
		{
			this.content = content;
			Delimiter = delimiter;
		}

		protected override
		void write( )
		{
			if(content.Any())
			{
				for ( int _i = 0; _i < content.Count( ) - 1; _i++ )
				{
					content[ _i ].Write( );
					Delimiter.Write( );
				}
				content.Last( ).Write( );
			}
		}
	}
}