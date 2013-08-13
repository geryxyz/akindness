using System;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Formating.Container
{
	public
	class Placed< TValue >
	: ConcurrentCommunicable
	{
		public
		int X { get; private set; }

		public
		int Y { get; private set; }

		public
		TValue Value { get; private set; }

		public
		Placed( TValue value, int x, int y )
		{
			X = x;
			Y = y;
			Value = value;
		}

		protected override
		void write( )
		{
			int _x = Console.CursorLeft;
			int _y = Console.CursorTop;
			Console.CursorLeft = X;
			Console.CursorTop = Y;
			Value.Write( );
			Console.CursorLeft = _x;
			Console.CursorTop = _y;
		}

		public override
		ConcurrentCommunicable SayAsync( )
		{
			Value.SayAsync( );
			return this;
		}

		public override
		ConcurrentCommunicable SaySync( )
		{
			Value.SaySync( );
			"at".SaySync( );
			X.SaySync( );
			Y.SaySync( );
			return this;
		}
	}
}