//AKindnessCommands:
using System;
using System.Drawing;
using System.Speech.Synthesis;
using System.Text;
using AKindnessCommands.Model.Output;
using AKindnessCommons.Wrapper;

namespace AKindnessCommands.Model.Emitter
{
	public
	class TextToSpeechEmitter
	: Emitter
	{
		readonly
		SpeechSynthesizer mouth = new SpeechSynthesizer( );

		public override
		void EmitSingle( CommandOutput output )
		{
			StringBuilder _speech = new StringBuilder( );
			switch ( output.Level )
			{
				case OutputLevel.Information:
					break;
				case OutputLevel.Warning:
					_speech.AppendFormat( "There is a warning at {0}: ", output.CreationTime );
					break;
				case OutputLevel.Error:
					_speech.AppendFormat( "An error accured at {0}: ", output.CreationTime );
					break;
				default:
					throw new ArgumentOutOfRangeException( );
			}

			if ( !output.Message.GetBool( "do not read" ) )
			{
				_speech.Append(
					output.Message.GetString( "language" ) == "english"
						? output.Message.Value
						: "Unknown language, please read it yourself." );
				_speech.Replace( "::", " argument of kindness " );
			}

			if ( output.Message.GetBool( "sync" ) )
			{
				mouth.Speak( _speech.ToString( ) );
			}
			else
			{
				mouth.SpeakAsync( _speech.ToString( ) );
			}
		}

		public override void EmitSingle( PropertyDecorator< string > input )
		{
		}

		protected override void clearRectangle( Rectangle region )
		{
			throw new NotSupportedException( );
		}
	}
}

