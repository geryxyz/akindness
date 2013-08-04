//AKindnessCommands:
using System;

namespace AKindnessCommands.EventRelated
{
	public
	class EventArgs<TValue>
	: EventArgs
	{
		public
		TValue Value { get; private set; }

		public
		EventArgs( TValue value )
		{
			Value = value;
		}
	}
}

