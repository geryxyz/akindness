using System;
using AKindnessCommands.Extension;
using AKindnessCommands.Formating.Container;

namespace AKindnessCommands.Formating.Flow
{
	public static
	class TaggedFlow
	{
		public static
		Tagged<TTag,TValue> Tagged<TTag,TValue>(this FlowConnector<TValue> input, TTag tag)
		{
			return new Tagged< TTag, TValue >( tag, input.Value );
		}

		public static
		Tagged<string,TValue> TaggedAsQuestion<TValue>(this FlowConnector<TValue> input )
		{
			return input.Value.Let( ).Tagged( "?" );
		}

		public static
		Tagged<string,TValue> TaggedAsInformation<TValue>(this FlowConnector<TValue> input )
		{
			return input.Value.Let( ).Tagged( ":" );
		}
	
		public static
		Tagged<string,TValue> TaggedAsWarning<TValue>(this FlowConnector<TValue> input )
		{
			return input.Value.Let( ).Tagged( "*" );
		}
		
		public static
		Tagged<string,TValue> TaggedAsError<TValue>(this FlowConnector<TValue> input )
		{
			return input.Value.Let( ).Tagged( "!" );
		}

		public static
		Tagged<Colored<string>,Colored<TValue>> TaggedAsColoredQuestion<TValue>(this FlowConnector<TValue> input )
		{
			return input.Value.Let( ).Colored( ConsoleColor.DarkGreen )
				.Let( ).Tagged( "?".Let( ).Colored( ConsoleColor.Green ) );
		}

		public static
		Tagged<Colored<string>,Colored<TValue>> TaggedAsColoredInformation<TValue>(this FlowConnector<TValue> input )
		{
			return input.Value.Let( ).Colored( ConsoleColor.DarkGray )
				.Let( ).Tagged( ":".Let( ).Colored( ConsoleColor.White ) );
		}
	
		public static
		Tagged<Colored<string>,Colored<TValue>> TaggedAsColoredWarning<TValue>(this FlowConnector<TValue> input )
		{
			return input.Value.Let( ).Colored( ConsoleColor.DarkYellow )
				.Let( ).Tagged( "*".Let( ).Colored( ConsoleColor.Yellow ) );
		}
		
		public static
		Tagged<Colored<string>,Colored<TValue>> TaggedAsColoredError<TValue>(this FlowConnector<TValue> input )
		{
			return input.Value.Let( ).Colored( ConsoleColor.DarkRed )
				.Let( ).Tagged( "!".Let( ).Colored( ConsoleColor.Red ) );
		}
	}
}