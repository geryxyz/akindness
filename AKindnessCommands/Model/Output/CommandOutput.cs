//AKindnessCommands:
using System;
using AKindnessCommons.Wrapper;

namespace AKindnessCommands.Model.Output
{
	public
	struct CommandOutput
	{
		public readonly
		OutputLevel Level;
		public readonly
		PropertyDecorator<string> Message;
		public readonly
		DateTime CreationTime;

		public
		CommandOutput( OutputLevel level, PropertyDecorator<string> message, DateTime creationTime)
		: this( )
		{
			Level = level;
			Message = message;
			CreationTime = creationTime;
		}
	}
}

