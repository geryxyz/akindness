//AKindnessCommands:
using System;
using AKindnessCommands.Extension;
using AKindnessCommons.EventRelated;

namespace AKindnessCommands.Model.Input
{
	public
	class ConsoleInputCollector
	: InputCollector
	{
		public
		ConsoleInputCollector( string name )
		: base( name ) { }

		public override
		void Enqueue( )
		{
			ConsoleKeyInfo _key = Console.ReadKey( true );
			onKeyPressed( new EventArgs< ConsoleKeyInfo >( _key ) );
			switch ( _key.Key )
			{
				case ConsoleKey.Backspace:
					if ( !string.IsNullOrEmpty( CurrentLine.ToString( ) ) )
					{
						CurrentLine.Remove( CurrentLine.Length - 1, 1 );
						onCurrentLineChanged( EventArgs.Empty );
					}
					break;
				case ConsoleKey.LeftArrow:
				case ConsoleKey.RightArrow:
				case ConsoleKey.UpArrow:
				case ConsoleKey.DownArrow:
					break;
				case ConsoleKey.Enter:
					InputLines.Enqueue( CurrentLine.ToString( ) );
					CurrentLine.Clear( );
					onCurrentLineChanged( EventArgs.Empty );
					onNewInputLineAdded( EventArgs.Empty );
					break;
				default:
					CurrentLine.Append( _key.KeyChar );
					onCurrentLineChanged( EventArgs.Empty );
					break;
			}
		}
	}
}

