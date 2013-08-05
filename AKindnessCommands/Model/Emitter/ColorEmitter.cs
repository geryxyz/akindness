//AKindnessCommands:
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using AKindnessCommands.Exceptions;
using AKindnessCommands.Extension;
using AKindnessCommands.Model.Output;
using AKindnessCommands.Model.Token;
using AKindnessCommons.EventRelated;
using AKindnessCommons.Wrapper;

namespace AKindnessCommands.Model.Emitter
{
	public
	class ColorEmitter
	: Emitter
	{
		public 
		ColorEmitter( params Cursor.Cursor[ ] cursors )
		: base(cursors) { }

		protected
		event EventHandler beforClearOutput;

		public override
		void EmitSingle( CommandOutput output)
		{
			Cursor.Cursor _mainCursor = getCursorBy( "main" );
			if ( _mainCursor.NeedToClear )
			{
				beforClearOutput.Raise( this, EventArgs.Empty );
				clear( );
			}
			Console.SetCursorPosition(
				_mainCursor.Position.X,
				_mainCursor.Position.Y );
			switch ( output.Level )
			{
				case OutputLevel.Information:
					"[i] {0} {1}\n".Format(
						output.CreationTime,
						output.Message.Value ).ColorWrite( ConsoleColor.Cyan );
					break;
				case OutputLevel.Note:
					"[*] {0}\n".Format(
						( object )output.Message.Value ).ColorWrite( ConsoleColor.Yellow );
					break;
				case OutputLevel.Warning:
					"[w] {0} {1}\n".Format(
						output.CreationTime,
						output.Message.Value ).ColorWrite( ConsoleColor.Magenta );
					break;
				case OutputLevel.Error:
					"[!] {0} {1}\n".Format(
						output.CreationTime,
						output.Message.Value ).ColorWrite( ConsoleColor.Red );
					break;
				default:
					throw new ArgumentOutOfRangeException( );
			}
			_mainCursor.Update(
				new Point(
					0,
					Console.CursorTop - _mainCursor.Origin.Y ) );
		}

		public override
		void EmitSingle( PropertyDecorator< string > input )
		{
			clear( );
			Cursor.Cursor _mainCursor = getCursorBy( "main" );
			Cursor.Cursor _shadowCursor = getCursorBy( "shadow" );
			if ( !input.GetBool( "complete" ) )
			{
				Console.SetCursorPosition(
					_mainCursor.Position.X,
					_mainCursor.Position.Y );
				emitSyntax( input );
				_mainCursor.Update(
					new Point(
						0,
						_mainCursor.Origin.Y - Console.CursorTop ) );
				Console.SetCursorPosition(
					_shadowCursor.Position.X,
					_shadowCursor.Position.Y );
				emitRawInput( input );
				_shadowCursor.Update(
					new Point(
						0,
						_mainCursor.Origin.Y - Console.CursorTop ) );
			}
		}

		static
		void emitRawInput( PropertyDecorator< string > input )
		{
			input.Value.ColorWrite( ConsoleColor.DarkGreen );
		}

		static
		void emitSyntax( PropertyDecorator< string > input )
		{
			try
			{
				CommandInvocation _invocation = new CommandInvocation( input.Value );
				for ( int _i = 0; _i < _invocation.Tokens.Count( ); _i++ )
				{
					CommandToken _currentToken = _invocation.Tokens[ _i ];
					if ( _currentToken is Arg )
					{
						writeArg( _currentToken );
					}
					else if ( _currentToken is Word )
					{
						_currentToken.ToString( ).ColorWrite( ConsoleColor.Yellow );
					}
					if ( _i < _invocation.Tokens.Count( ) - 1 )
					{
						Console.Write( " " );
					}
				}
				if ( input.Value.EndsWith( " " ) )
				{
					" ".ColorWrite( ConsoleColor.Black );
				}
				" ".ColorWrite( ConsoleColor.Black, ConsoleColor.Green );
			}
			catch ( SyntaxErrorException )
			{
				input.Value.ColorWrite( ConsoleColor.Red );
			}
			catch ( Exception )
			{
				input.Value.ColorWrite( ConsoleColor.Black, ConsoleColor.Red );
			}
		}

		protected override
		void clearRectangle( Rectangle region )
		{
			for ( int _currentTop = region.Top; _currentTop < region.Bottom; _currentTop++ )
			{
				Console.SetCursorPosition( region.Left, _currentTop );
				Console.Write( "".PadLeft( region.Width ) );
			}
		}

		private static
		void writeArg( CommandToken currentToken )
		{
			Arg _currentArg = ( Arg )currentToken;
			_currentArg.Prefix.ColorWrite( ConsoleColor.Green );
			":".ColorWrite( ConsoleColor.DarkGreen );
			_currentArg.Value.ColorWrite( ConsoleColor.White );
			if ( _currentArg.Postfix != string.Empty )
			{
				":".ColorWrite( ConsoleColor.DarkGreen );
				_currentArg.Postfix.ColorWrite( ConsoleColor.Green );
			}
		}
	}
}

