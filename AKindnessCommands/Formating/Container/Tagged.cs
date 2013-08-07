using System;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Formating.Container
{
	public
	class Tagged<TBaseType>
	: ConcurrentWriteable
	{
		public
		string Tag { get; private set; }

		public
		TBaseType Value { get; private set; }

		public
		Tagged( string tag, TBaseType value )
		{
			Tag = tag;
			Value = value;
		}

		public override
		string ToString( )
		{
			return "[{0}]\t{1}\n".Form( new Replacement( Tag, Value.ToString( ) ) );
		}

		protected override
		void write( )
		{
			ToString( ).UnlockedWrite( );
		}
	}
}