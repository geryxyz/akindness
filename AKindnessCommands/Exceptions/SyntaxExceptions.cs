//AKindnessCommands:
using System;
using System.Runtime.Serialization;

namespace AKindnessCommands.Exceptions
{
	[ Serializable ]
	public class SyntaxErrorException : ApplicationException
	{
		public SyntaxErrorException( ) {}

		public SyntaxErrorException( string message )
			: base( message ) {}

		public SyntaxErrorException( string message, Exception inner )
			: base( message, inner ) {}

		protected SyntaxErrorException(
			SerializationInfo info,
			StreamingContext context )
			: base( info, context ) {}
	}
}

