using System;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Formating.Container
{
	public
	class Colored< TBaseType >
	: ConcurrentCommunicable
	{
		public
		TBaseType Value { get; private set; }

		public
		ConsoleColor TextColor { get; private set; }

		public
		ConsoleColor BackgroundColor { get; private set; }

		public
		Colored( TBaseType value, ConsoleColor textColor, ConsoleColor backgroundColor )
		{
			Value = value;
			TextColor = textColor;
			BackgroundColor = backgroundColor;
		}

		protected override
		void write( )
		{
			ConsoleColor _textTemp = Console.ForegroundColor;
			ConsoleColor _backgroundTemp = Console.BackgroundColor;
			Console.ForegroundColor = TextColor;
			Console.BackgroundColor = BackgroundColor;
			Value.Write( );
			Console.ForegroundColor = _textTemp;
			Console.BackgroundColor = _backgroundTemp;
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
			Value.SaySync(  );
			return this;
		}
	}
}