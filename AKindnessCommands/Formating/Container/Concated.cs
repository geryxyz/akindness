using System.Collections.Generic;
using System.Linq;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Formating.Container
{
	public
	class Concated<TValue,TDelimiter>
	: ConcurrentCommunicable
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
				int _count = content.Count( );
				for ( int _i = 0; _i < _count - 1; _i++ )
				{
					content[ _i ].Write( );
					Delimiter.Write( );
				}
				content.Last( ).Write( );
			}
		}

		public override
		ConcurrentCommunicable SayAsync( )
		{
			if(content.Any())
			{
				int _count = content.Count( );
				for ( int _i = 0; _i < _count - 1; _i++ )
				{
					content[ _i ].SayAsync( );
					Delimiter.SayAsync( );
				}
				content.Last( ).SayAsync( );
			}
			return this;
		}

		public override
		ConcurrentCommunicable SaySync( )
		{
			if(content.Any())
			{
				int _count = content.Count( );
				for ( int _i = 0; _i < _count - 1; _i++ )
				{
					content[ _i ].SaySync( );
					Delimiter.SaySync( );
				}
				content.Last( ).SaySync( );
			}
			return this;
		}
	}
}