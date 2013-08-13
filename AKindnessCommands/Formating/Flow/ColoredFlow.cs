using System;
using AKindnessCommands.Formating.Container;

namespace AKindnessCommands.Formating.Flow
{
	public static
	class ColoredFlow
	{
		public static
		Colored<TIn> Colored<TIn>(this FlowConnector<TIn> input, ConsoleColor textColor, ConsoleColor backgroundColor=ConsoleColor.Black)
		{
			return new Colored< TIn >( input.Value, textColor, backgroundColor );
		}
	}
}