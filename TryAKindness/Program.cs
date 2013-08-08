using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AKindnessCommands.Extension;
using AKindnessCommands.Formating;
using AKindnessCommands.Formating.Container;

namespace TryAKindness
{
	class Program
	{
		static void Main( string[ ] args )
		{
			"Examples:\n".Write( );
			"Colorize\n".Form( new Colorize< string >( ConsoleColor.Black, ConsoleColor.Gray ) ).Write( );
			"Tagged".Form( As.Tag( "tag" ) ).Write( );
			"Question".Form( Tag<string, string >.AsQuestion ).Write( );
			"Blue Question"
				.Form( Tag<string, string >.AsQuestion )
				.Form( new Colorize< Tagged<string, string > >( ConsoleColor.Cyan, ConsoleColor.Black ) )
				.Write( );
			"Blue Question"
				.Form( new Colorize< string >( ConsoleColor.Cyan, ConsoleColor.Black ) )
				.Form( Tag<string, Colored< string > >.AsQuestion )
				.Write( );
			"Fancy Blue Question"
				.Form( new Colorize< string >( ConsoleColor.Cyan, ConsoleColor.Black ) )
				.Form( new Tag< Colored< string >, Colored< string > >(
					"?"
						.Form( new Colorize< string >( ConsoleColor.DarkBlue, ConsoleColor.Cyan ) ) ) )
				.Write( );
			"Information".Form( Tag<string, string >.AsInformation ).Write( );
			"Warning".Form( Tag<string, string >.AsWarning ).Write( );
			"Error".Form( Tag<string, string >.AsError ).Write( );

			"\nScales:\n".Write( );
			1
				.Form( new ScaleInt( 0, 1, 0, 10 ) )
				.Form( new Colorize< double >( ConsoleColor.Yellow, ConsoleColor.Blue ) )
				.Write( );

			Console.Read( );
		}
	}
}
