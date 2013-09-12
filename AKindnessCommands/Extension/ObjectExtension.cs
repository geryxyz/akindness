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
		object Write( this Object self )
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
			return self;
		}

		public static
		object SayAsync(this Object self)
		{
			lock ( ConcurrentCommunicable.Mouth )
			{
				if ( self is ISpeakable )
				{
					( ( ISpeakable )self ).SayAsync( );
				}
				else
				{
					try
					{
						ConcurrentCommunicable.Mouth.SpeakAsync( self.ToString( ) );
					}
					catch { }
				}
			}
			return self;
		}

		public static
		object SaySync(this Object self)
		{
			lock ( ConcurrentCommunicable.Mouth )
			{
				if ( self is ISpeakable )
				{
					( ( ISpeakable )self ).SaySync( );
				}
				else
				{
					try
					{
						ConcurrentCommunicable.Mouth.Speak( self.ToString( ) );
					}
					catch { }
				}
			}
			return self;
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