//AKindnessCommands:
using System;
using System.Runtime.Serialization;

namespace AKindnessCommands.Exceptions
{
	[ Serializable ]
	public class UnknownCommandException : ApplicationException
	{
		public UnknownCommandException( ) {}

		public UnknownCommandException( string message )
			: base( message ) {}

		public UnknownCommandException( string message, Exception inner )
			: base( message, inner ) {}

		protected UnknownCommandException(
			SerializationInfo info,
			StreamingContext context )
			: base( info, context ) {}
	}
}

