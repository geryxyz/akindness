using System;

namespace AKindnessCommands.Formating
{
	public static
	class ObjectExtension
	{
		/// <summary>
		/// Implement concurrent writing of the object to the console.
		/// </summary>
		/// <param name="self"></param>
		public static
		void Write( this object self )
		{
			lock ( Console.Out )
			{
				Console.Write( self.ToString( ) );
			}
		}

		/// <summary>
		/// Implement non-concurrent writing of object ot the console.
		/// Use to avoid dead-locks when implementing ConncurentWriteable.write( ).
		/// </summary>
		/// <param name="self"></param>
		public static
		void UnlockedWrite( this object self )
		{
			Console.Write( self.ToString( ) );
		}
	}
}