using System;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Formating.Container
{
	public
	class Tagged<TTagType,TBaseType>
	: ConcurrentWriteable
	{
		public
		TTagType Tag { get; private set; }

		public
		TBaseType Value { get; private set; }

		public
		Tagged( TTagType tag, TBaseType value )
		{
			Tag = tag;
			Value = value;
		}

		public override
		string ToString( )
		{
			return "[{0}]\t{1}\n".Form( new Replacement( Tag, Value ) );
		}

		protected override
		void write( )
		{
			"[".Write( );
			Tag.Write( );
			"]\t".Write( );
			Value.Write( );
			"\n".Write( );
		}
	}

	public static
	class TaggedFlow
	{
		public static
		Tagged<TTag,TValue> Tagged<TTag,TValue>(this FlowConnector<TValue> input, TTag tag)
		{
			return new Tagged< TTag, TValue >( tag, input.Value );
		}
	}
}