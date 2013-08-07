using System;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Model.ConsoleUI
{
	public
	class FillUpProgressBar
	: ProgressBar
	{
		public FillUpProgressBar( int width, ConsoleColor background, ConsoleColor forground, double max )
		: base( width, background, forground )
		{
			Max = max;
		}

		public
		double Max { get; set; }

		public
		double State { get; set; }

		public override void Update( )
		{
			lock ( this )
			{
				State++;
			}
		}

		protected override
		void render( )
		{
			lock ( this )
			{
				double _donePrecent = State / Max;
				if ( IsDumpState )
				{
					"{0:0.00} of {1:0.00} is {2:p}".Form(
						State, Max, _donePrecent ).ColorWriteLine(
							Forground, Background );
				}
				if ( State < Max )
				{
					double _leftOverPrecent = 1 - _donePrecent;
					"".PadLeft( ( int )( _donePrecent * Width ) ).ColorWrite( Forground, Forground );
					"".PadLeft( ( int )( _leftOverPrecent * Width ) ).ColorWrite( Background, Background );
				}
				else
				{
					"".PadLeft( Width ).ColorWrite( Forground, Forground );
				}
			}
		}
	}
}