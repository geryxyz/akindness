//AKindnessCommands:

using System;
using System.Threading;

namespace AKindnessCommons.EventRelated
{
	public static
	class EventHandlerExtension
	{
		public static
		void Raise( this EventHandler self, object sender, EventArgs args )
		{
			EventHandler _temp = self;
			if ( _temp != null )
			{
				_temp( sender, args );
			}
		}

		public static
		void Raise<T>( this EventHandler<T> self, object sender, T args )
		where T : EventArgs
		{
			EventHandler<T> _temp = self;
			if ( _temp != null )
			{
				_temp( sender, args );
			}
		}

		public static
		void BeginRaise( this EventHandler self, object sender, EventArgs args )
		{
			new Thread( new ThreadStart( delegate
				{
					EventHandler _temp = self;
					if ( _temp != null )
					{
						_temp( sender, args );
					}
				} ) ).Start( );
		}

		public static
		void BeginRaise<T>( this EventHandler<T> self, object sender, T args )
		where T : EventArgs
		{
			new Thread( new ThreadStart( delegate
				{
					EventHandler<T> _temp = self;
					if ( _temp != null )
					{
						_temp( sender, args );
					}
				} ) ).Start( );
		}
	}
}

