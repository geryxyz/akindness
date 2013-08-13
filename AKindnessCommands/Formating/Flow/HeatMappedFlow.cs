using System;
using System.Collections.Generic;
using System.Linq;
using AKindnessCommands.Extension;
using AKindnessCommands.Formating.Container;

namespace AKindnessCommands.Formating.Flow
{
	public static
		class HeatMappedFlow
	{
		public static
			ConsoleColor HeatMapped(
			this FlowConnector< double > input, IEnumerable< ConsoleColor > palette, double min = 0, double max = 1 )
		{
			IEnumerable< ConsoleColor > _palette = palette as ConsoleColor[ ] ?? palette.ToArray( );
			return _palette.ElementAt( ( int )input.Scale( min, max, 0, _palette.Count( ) ) );
		}

		public static
			ConsoleColor HeatMapped(
			this FlowConnector< int > input, IEnumerable< ConsoleColor > palette, int min = 0, int max = 100 )
		{
			IEnumerable< ConsoleColor > _palette = palette as ConsoleColor[ ] ?? palette.ToArray( );
			return _palette.ElementAt( ( int )input.Scale( min, max, 0, _palette.Count( ) ) );
		}

		public static
			Colored< string > HeatColored(
			this FlowConnector< double > input, IEnumerable< ConsoleColor > palette, double min = 0, double max = 1 )
		{
			IEnumerable< ConsoleColor > _palette = palette as ConsoleColor[ ] ?? palette.ToArray( );
			return " ".Let( ).Colored(
				ConsoleColor.Black,
				_palette.ElementAt( ( int )input.Scale( min, max, 0, _palette.Count( ) ) ) );
		}

		public static
			Colored< string > HeatColored(
			this FlowConnector< int > input, IEnumerable< ConsoleColor > palette, int min = 0, int max = 100 )
		{
			IEnumerable< ConsoleColor > _palette = palette as ConsoleColor[ ] ?? palette.ToArray( );
			return " ".Let( ).Colored(
				ConsoleColor.Black,
				_palette.ElementAt( ( int )input.Scale( min, max, 0, _palette.Count( ) ) ) );
		}

		public static readonly
		ConsoleColor[ ] ClassicPalette =
			new[ ]
				{
					ConsoleColor.DarkRed,
					ConsoleColor.Red,
					ConsoleColor.DarkYellow,
					ConsoleColor.Yellow,
					ConsoleColor.White,
					ConsoleColor.Cyan,
					ConsoleColor.DarkCyan,
					ConsoleColor.Blue,
					ConsoleColor.DarkBlue
				};
	}
}