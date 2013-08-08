using System;
using AKindnessCommands.Formating;

namespace AKindnessCommands.Extension
{
	public static
	class ObjectExtension
	{
		/// <summary>
		/// Implement concurrent writing of the object to the console.
		/// </summary>
		/// <param name="self"></param>
		public static
		void Write( this Object self )
		{
			lock ( Console.Out )
			{
				if ( self is IWriteable )
				{
					( ( IWriteable )self ).Write( );
				}
				else
				{
					Console.Write( self.ToString( ) );
				}
			}
		}

		public static
		TOut Form<TIn,TOut>(this TIn self, Format<TIn,TOut> format)
		{
			return format.Apply( self );
		}
	}
}