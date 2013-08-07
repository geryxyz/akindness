using System;
using AKindnessCommands.Formating.Container;

namespace AKindnessCommands.Formating
{
	public
	class Colorize<TIn>
	: Format<TIn, Colored<TIn> >
	{
		ConsoleColor textColor;

		ConsoleColor backgroundColor;

		public
		Colorize( ConsoleColor textColor, ConsoleColor backgroundColor )
		{
			this.textColor = textColor;
			this.backgroundColor = backgroundColor;
		}

		public override
		Colored< TIn > Apply( TIn input )
		{
			return new Colored< TIn >( input, textColor, backgroundColor );
		}
	}
}