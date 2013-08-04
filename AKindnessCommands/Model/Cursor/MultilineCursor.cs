//AKindnessCommands:
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AKindnessCommands.Model.Cursor
{
	public
	class MultilineCursor
	: Cursor
	{
		public
		MultilineCursor( Point origin, int lineNumeber )
		: base( origin )
		{
			this.lineNumeber = lineNumeber;
			NeedToClear = false;
		}

		readonly
		int lineNumeber;

		public override
		void Update( Point change )
		{
			if ( RemainingArea.Height > change.Y &&
			     Origin.Y + change.Y < lineNumeber )
			{
				Position = new Point( 0, Origin.Y + change.Y );
				NeedToClear = false;
			}
			else
			{
				Position = Origin;
				NeedToClear = true;
			}
		}

		public override
		void Refresh( Point change )
		{
			Position =
				new Point(
					Math.Max(
						change.X,
						Origin.X + Area.Width ),
					Position.Y );
		}

		public override
		IEnumerable< Rectangle > ClearingRegions
		{
			get
			{
				return
					new List< Rectangle >
						{
							new Rectangle(
								Origin,
								new Size( Console.WindowWidth, lineNumeber ) )
						};
			}
		}
	}
}

