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

		public
		void UnlockedWrite( )
		{
			write( );
		}

		protected abstract
		void write( );
	}
}