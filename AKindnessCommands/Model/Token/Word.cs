//AKindnessCommands:
using System.Text.RegularExpressions;
using AKindnessCommands.Exceptions;

namespace AKindnessCommands.Model.Token
{
	public
	class Word
	: CommandToken
	{
		public
		Word(string text)
		{
			if ( Regex.IsMatch( text, @"[\w0-9]+" ) )
			{
				Value = text;
			}
			else
			{
				throw new SyntaxErrorException( string.Format( "Invalid character in the word: {0}", text ) );
			}
		}

		public override
		string ToString( )
		{
			return Value;
		}
	}
}

