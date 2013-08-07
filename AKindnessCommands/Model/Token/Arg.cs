//AKindnessCommands:
using System;
using System.Linq;
using System.Text;
using AKindnessCommands.Exceptions;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Model.Token
{
	public 
	class Arg
	: CommandToken
	{
		public
		Arg( string argString )
		{
			if ( argString.Contains( ':' ) )
			{
				string[ ] _parts = argString.Split( ':' );
				if ( _parts.Count( ) == 2 )
				{
					Prefix = _parts[ 0 ];
					Value = unEscape( _parts[ 1 ] );
					Postfix = string.Empty;
				}
				else if ( _parts.Count( ) == 3 )
				{
					Prefix = _parts[ 0 ];
					Value = unEscape( _parts[ 1 ] );
					Postfix = _parts[ 2 ];
				}
				else
				{
					throw new SyntaxErrorException( string.Format( "Wrong arg format: {0}", argString ) );
				}
			}
			else
			{
				throw new SyntaxErrorException( string.Format( "Wrong arg format: {0}", argString ) );
			}
		}

		static string unEscape( string text)
		{
			char _escapeChar = '~';
			var _subescapes = text.Split(
				new[ ] { "".PadLeft( 2, _escapeChar ) },
				StringSplitOptions.None );
			for ( int _i = 0; _i < _subescapes.Count( ); _i++ )
			{
				_subescapes[ _i ] = _subescapes[ _i ].
					Replace( "{0}s".Form( _escapeChar ), " " ).
					Replace( "{0}c".Form( _escapeChar ), ":" );
			}
			StringBuilder _builder = new StringBuilder( _subescapes.First( ) ?? string.Empty );
			_subescapes.Skip( 1 ).ToList( ).ForEach(
				_current => _builder.AppendFormat( "{0}{1}", _escapeChar, _current ) );
			return _builder.ToString( );
		}

		public static
		bool IsArg( string candidate )
		{
			int _count = candidate.Count( _c => _c.Equals( ':' ) );
			return
				( _count == 2 || _count == 1 ) &&
				( !candidate.Contains( ' ' ) ) &&
				!string.IsNullOrWhiteSpace( candidate );
		}

		public
		string Prefix { get; private set; }
		public
		string Postfix { get; private set; }

		public override
		string ToString( )
		{
			if ( Postfix==string.Empty )
			{
				return "{0}:{1}".Form( ( object )Prefix, Value );
			}
			if ( Prefix==string.Empty )
			{
				return "{0}:{1}".Form( ( object )Value, Postfix );
			}
			if ( Prefix==string.Empty&&Postfix==string.Empty )
			{
				return ":{0}".Form( ( object )Value );
			}
			return "{0}:{1}:{2}".Form( ( object )Prefix, Value, Postfix );
		}
	}
}

