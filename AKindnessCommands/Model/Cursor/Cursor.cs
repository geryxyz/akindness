//AKindnessCommands:
using System.Collections.Generic;
using System.Drawing;

namespace AKindnessCommands.Model.Cursor
{
	public abstract
	class Cursor
	{
		protected
		Cursor( Point origin )
		{
			Origin = origin;
			Position = origin;
		}

		public
		bool NeedToClear { get; protected set; }

		public
		string Name { get; set; }

		public
		Point Origin { get; private set; }
		public
		Size Area { get; set; }
		public
		Point Position { get; protected set; }
		public
		Size RemainingArea
		{
			get
			{
				return new Size( Area.Width - Position.X, Area.Height - Position.Y );
			}
		}

		public abstract
		void Update( Point change );

		public abstract
		void Refresh( Point change );

		public
		void Reset( )
		{
			Position = Origin;
		}

		public abstract
		IEnumerable< Rectangle > ClearingRegions { get; }
	}
}

