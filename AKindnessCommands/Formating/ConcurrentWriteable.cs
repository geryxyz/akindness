using System;

namespace AKindnessCommands.Formating
{
	public abstract
	class ConcurrentWriteable
	: IWriteable
	{
		public
		void Write( )
		{
			lock ( Console.Out )
			{
				write( );
			}
		}

		protected abstract
		void write( );
	}
}