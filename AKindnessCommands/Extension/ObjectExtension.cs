using System;
using System.Diagnostics;
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
		FlowConnector< TIn > Let< TIn >( this TIn input )
		{
			Debug.Assert(
				!( input is IFlowConnector ),
				"I do not intent to use this function more then one in a row. However you can use it that way for debuging or tracing." );
			return new FlowConnector< TIn >( input );
		}
	}
}