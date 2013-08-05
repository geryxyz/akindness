using System;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Model.ConsoleUI
{
	public
	class BouncingProgressBar
	: ProgressBar
	{
		int state = 0;
		int incremens = 1;

		public
		BouncingProgressBar( int width, ConsoleColor background, ConsoleColor forground )
		: base( width, background, forground ) {}

		int speed;
		public
		int Speed
		{
			get
			{
				return speed;
			}
			set
			{
				speed = value;
				incremens = value;
			}
		}

		public override
		void Update( )
		{
			state += incremens;
			if ( Width - 3 < state )
			{
				incremens = -1*Speed;
				state = Width - 3;
			}

			if( state < 0)
			{
				incremens = Speed;
				state = 0;
			}
		}

		protected override
		void render( )
		{
			int _preBlock = state;
			int _postBlock = Width - ( _preBlock + 3 );
			"".PadLeft( _preBlock ).ColorWrite( Background, Background );
			"".PadLeft( 3 ).ColorWrite( Forground, Forground );
			"".PadLeft( _postBlock ).ColorWrite( Background, Background );
		}
	}
}