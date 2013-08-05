using System;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Model.ConsoleUI
{
	public abstract
	class ProgressBar
	{
		public
		int Width { get; private set; }

		public
		int X { get; set; }

		public
		int Y { get; set; }

		public
		bool IsDumpState { get; set; }

		public
		ConsoleColor Background { get; private set; }

		public
		ConsoleColor Forground { get; private set; }

		public
		ProgressBar( int width, ConsoleColor background, ConsoleColor forground )
		{
			Width = width;
			Background = background;
			Forground = forground;
			IsDumpState = true;
		}

		public abstract
		void Update( );

		public
		void Display( )
		{
			lock ( Console.Out )
			{
				Console.SetCursorPosition( X, Y );
				int _x = Console.CursorLeft;
				int _y = Console.CursorTop;
				ConsoleColor _fg = Console.ForegroundColor;
				ConsoleColor _bg = Console.BackgroundColor;
				render( );
				Console.ForegroundColor = _fg;
				Console.BackgroundColor = _bg;
				Console.SetCursorPosition( _x, _y );
			}
		}

		protected abstract
		void render( );
	}
}