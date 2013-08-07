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
			"Tagged".Form( new Tag< string >( "tag" ) ).Write( );
			"Question".Form( Tag< string >.AsQuestion ).Write( );
			"Information".Form( Tag< string >.AsInformation ).Write( );
			"Warning".Form( Tag< string >.AsWarning ).Write( );
			"Error".Form( Tag< string >.AsError ).Write( );
			Console.Read( );
		}
	}
}
