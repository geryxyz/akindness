//AKindnessCommands:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AKindnessCommands.Exceptions;
using AKindnessCommands.Model.Token;

namespace AKindnessCommands.Model
{
	public
	class CommandInvocation
	{
		public
		string FingerPrint { get; private set; }
		Arg[ ] args { get; set; }
		public
		CommandToken[ ] Tokens { get; set; }

		public
		CommandInvocation( string userInput )
		{
			StringBuilder _fingerPrint = new StringBuilder( );
			List< Arg > _args = new List< Arg >( );
			List< CommandToken > _tokens = new List< CommandToken >( );

			var _rawTokens = userInput.Split( ' ' );
			foreach ( var _currentRawToken in _rawTokens )
			{
				if ( _currentRawToken.Length > 0 )
				{
					if ( Arg.IsArg( _currentRawToken ) )
					{
						Arg _arg = new Arg( _currentRawToken );
						_args.Add( _arg );
						_tokens.Add( _arg );
						_fingerPrint.AppendFormat( "{0}::{1} ", _arg.Prefix, _arg.Postfix );
					}
					else if (!_currentRawToken.Contains( ':' ))
					{
						_tokens.Add( new Word( _currentRawToken ) );
						_fingerPrint.AppendFormat( "{0} ", _currentRawToken );
					}
					else
					{
						throw new SyntaxErrorException( string.Format( "Wrong format: {0}", _currentRawToken ) );
					}
				}
			}

			Tokens = _tokens.ToArray( );
			FingerPrint = _fingerPrint.ToString( ).Trim( );
			args = _args.ToArray( );
		}

		/// <summary>
		/// Get the first arg match by the given regular expression index.
		/// </summary>
		/// <param name="index">An regular expression index contains one and only one colon (:)</param>
		/// <returns>The frist arg match with the given regular expression index.</returns>
		public
		Arg this[ string index ]
		{
			get
			{
				if ( index.Count( _c => _c == ':' ) == 1 )
				{
					string[ ] _tokens = index.Split( ':' );
					if ( index.StartsWith( ":" ) )
					{
						string _postfixPattern = index.Substring( 1 );
						foreach ( Arg _currentArg in args )
						{
							if ( Regex.IsMatch( _currentArg.Postfix, _postfixPattern ) )
							{
								return _currentArg;
							}
						}
					}
					else if ( index.EndsWith( ":" ) )
					{
						string _prefixPattern = index.Substring( 0, index.Count( ) - 1 );
						foreach ( Arg _currentArg in args )
						{
							if ( Regex.IsMatch( _currentArg.Prefix, _prefixPattern ) )
							{
								return _currentArg;
							}
						}
					}
					else
					{
						string _prefixPattern = _tokens.First( );
						string _postfixPattern = _tokens.Last( );
						foreach ( Arg _currentArg in args )
						{
							if ( Regex.IsMatch( _currentArg.Prefix, _prefixPattern ) &&
							     Regex.IsMatch( _currentArg.Postfix, _postfixPattern ) )
							{
								return _currentArg;
							}
						}
					}
				}
				else
				{
					throw new ArgumentException( "Wrong search pattern. You have to specify a pattern with exactly one colon (:)." );
				}
				throw new KeyNotFoundException( "There isn't any arg match with the given pattern." );
			}
		}
	}
}

