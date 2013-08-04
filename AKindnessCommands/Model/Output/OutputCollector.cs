//AKindnessCommands:
using System;
using System.Collections.Generic;
using System.Linq;
using AKindnessCommands.Extension;
using AKindnessCommands.Model.Wrapper;
using AKindnessCommons.Extension;

namespace AKindnessCommands.Model.Output
{
	public
	class OutputCollector
	{
		readonly
		Queue< CommandOutput > outputs = new Queue< CommandOutput >( );
		public
		string Name { get; private set; }

		public OutputCollector(string name)
		{
			Name = name;
		}

		public
		bool Any( )
		{
			return outputs.Any( );
		}

		public
		void Enqueue(CommandOutput output)
		{
			outputs.Enqueue( output );
			NewOutputReceived.Raise( this, new EventArgs( ) );
		}

		public
		void Enqueue( PropertyDecorator< string > message, OutputLevel level = OutputLevel.Information )
		{
			Enqueue(
				new CommandOutput(
					level, message, DateTime.Now ) );
		}

		public
		CommandOutput Dequeue()
		{
			return outputs.Dequeue( );
		}

		public
		IEnumerable< CommandOutput > PeekAll()
		{
			return outputs;
		}

		public
		CommandOutput Peek()
		{
			return outputs.Peek( );
		}

		public
		event EventHandler NewOutputReceived;

		public
		void Clear( )
		{
			outputs.Clear( );
		}
	}
}

