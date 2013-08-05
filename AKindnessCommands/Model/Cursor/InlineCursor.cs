//AKindnessCommands:
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AKindnessCommands.Model.Cursor
{
	public
		class InlineCursor
		: Cursor
	{
		public
			InlineCursor( Point origin )
			: base( origin )
		{
			NeedToClear = true;
		}

		public override
		void Update( Point change )
		{
			Position = Origin;
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

		public override IEnumerable< Rectangle > ClearingRegions
		{
			get
			{
				return
					new List< Rectangle >
						{
							new Rectangle( Origin, new Size( Console.WindowWidth - Origin.X, 1 ) )
						};
			}
		}
	}
}

