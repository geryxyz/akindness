//AKindnessCommands:
using System;
using AKindnessCommands.Exceptions;
using AKindnessCommands.UserInterface;

namespace AKindnessCommands.Model
{
	public class Command
	{
		public
		string FingerPrint { get; set; }
		private readonly
		Action< CommandInvocation, Context > body;

		public Command( string fingerPrint, Action<CommandInvocation, Context> body )
		{
			FingerPrint = new CommandInvocation( fingerPrint ).FingerPrint;
			this.body = body;
		}

		public
		void Execute(CommandInvocation input, Context context)
		{
			if ( input.FingerPrint == FingerPrint )
			{
				if ( body != null )
				{
					body( input, context );
				}
			}
			else
			{
				throw new SyntaxErrorException(
					string.Format( "Bad finger print: {0} against {1}", input.FingerPrint, FingerPrint ) );
			}
		}
	}
}

