using System;
using System.Speech.Synthesis;

namespace AKindnessCommands.Formating
{
	public abstract
	class ConcurrentCommunicable
	: IWriteable
	, ISpeakable
	{
		public
		ConcurrentCommunicable Write( )
		{
			lock ( Console.Out )
			{
				write( );
			}
			return this;
		}

		protected abstract
		void write( );

		static public
		SpeechSynthesizer Mouth = new SpeechSynthesizer( );

		public abstract
		ConcurrentCommunicable SayAsync( );

		public abstract
		ConcurrentCommunicable SaySync( );
	}
}