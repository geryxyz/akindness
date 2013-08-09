using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AKindnessCommands.Extension;
using AKindnessCommands.Formating;
using AKindnessCommands.Formating.Container;
using AKindnessCommands.Formating.Flow;

namespace TryAKindness
{
	class Program
	{
		static void Main( string[ ] args )
		{
			"Examples:\n".Write( );
			"Colorize\n"
				.Let( ).Colored( ConsoleColor.Black, ConsoleColor.Red ).Write( );
			"Tagged"
				.Let( ).Colored( ConsoleColor.Black, ConsoleColor.Red )
				.Let( ).Tagged( "tag" )
				.Write( );
			"Tagged".Let( ).Tagged( "tag" ).Write( );
			"Question".Let( ).TaggedAsQuestion( ).Write( );
			"Information".Let( ).TaggedAsInformation( ).Write( );
			"Waring".Let( ).TaggedAsWarning( ).Write( );
			"Error".Let( ).TaggedAsError( ).Write( );
			"ColoredQuestion".Let( ).TaggedAsColoredQuestion( ).Write( );
			"ColoredInformation".Let( ).TaggedAsColoredInformation( ).Write( );
			"ColoredWaring".Let( ).TaggedAsColoredWarning( ).Write( );
			"ColoredError".Let( ).TaggedAsColoredError( ).Write( );
			new object[ ] { "This", "will".Let( ).Colored( ConsoleColor.Green ), "be", "concated" }
				.Let( ).Concated( "+".Let( ).Colored( ConsoleColor.DarkGray ) )
				.Let( ).Append( "\n" ).Write( );
			"This "
				.Let( ).Append( "append to " )
				.Let( ).Append( "this " ).Write( );
			"\n1 from [0;10] will be scaled to {0} from [0;1].".Let( ).Format( 1.Let( ).Scale( 0, 10, 0, 1 ) ).Write( );
			"\nHeatMapped:\n".Write( );
			for ( int _i = 0; _i < 50; _i++ )
			{
				_i.Let( ).HeatMapped(
					new[ ]
					{
						ConsoleColor.DarkRed, ConsoleColor.Red, ConsoleColor.DarkYellow, ConsoleColor.Yellow,
						ConsoleColor.White, ConsoleColor.Cyan, ConsoleColor.DarkCyan, ConsoleColor.Blue, ConsoleColor.DarkBlue,
					},
					0,50).Write( );
			}

			Console.Read( );
		}
	}
}
