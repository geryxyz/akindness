﻿using System;
using AKindnessCommands.Extension;
using AKindnessCommands.Formating.Flow;

namespace AKindnessCommands.Formating.Container
{
	public
	class Tagged<TTagType,TBaseType>
	: ConcurrentWriteable
	{
		public
		TTagType Tag { get; private set; }

		public
		TBaseType Value { get; private set; }

		public
		Tagged( TTagType tag, TBaseType value )
		{
			Tag = tag;
			Value = value;
		}

		public override
		string ToString( )
		{
			return "[{0}]\t{1}\n".Let( ).Format( Tag, Value );
		}

		protected override
		void write( )
		{
			"[".Write( );
			Tag.Write( );
			"]\t".Write( );
			Value.Write( );
			"\n".Write( );
		}
	}
}