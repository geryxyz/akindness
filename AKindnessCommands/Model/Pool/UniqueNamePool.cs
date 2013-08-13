//AKindnessCommands:
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using AKindnessCommands.Extension;


namespace AKindnessCommands.Model.Pool
{
	public class UniqueNamePool
	{
		Queue<string> uniqueParts = new Queue< string >();

		public
		string Prefix { get; private set; }

		public
		int Capacity { get; private set; }

		public
		int biggestUniquePart = 0;

		public
		UniqueNamePool( string prefix, int capacity )
		{
			Capacity = capacity;
			Prefix = prefix;
		}

		public
		string RequestName( )
		{
			lock( this )
			{
				if ( !uniqueParts.Any( ) )
				{
					for ( int _i = 0; _i < Capacity; _i++ )
					{
						uniqueParts.Enqueue( biggestUniquePart + _i.ToString( ) );
					}
					biggestUniquePart += Capacity;
				}
				return "{0}#{1}".LegacyForm( ( object )Prefix, uniqueParts.Dequeue( ) );
			}
		}

		public
		void ReleaseName(string name)
		{
			if ( name!=null )
			{
				lock ( this )
				{
					Match _match = Regex.Match( name, @"^(?<prefix>\w*)#(?<number>\d+)$" );
					if ( _match.Success &&
					     _match.Groups[ "prefix" ].Value == Prefix )
					{
						uniqueParts.Enqueue( _match.Groups[ "number" ].Value );
					}
				}
			}
		}

		public
		bool IsMine( string name )
		{
			return Regex.IsMatch( name, @"^(?<prefix>\w*)#(?<number>\d+)$" );
		}
	}
}
