//AKindnessCommands:

using System;
using System.Collections.Generic;

namespace AKindnessCommons.Wrapper
{
	public
	class PropertyDecorator<TValue>
	{
		readonly
		Dictionary< string, Enum > enumPropertys =
			new Dictionary< string, Enum >( );
		readonly
		Dictionary< string, bool > boolPropertys =
			new Dictionary< string, bool >( );
		readonly
		Dictionary< string, double > doublePropertys =
			new Dictionary< string, double >( );
		readonly
		Dictionary< string, string > stringPropertys =
			new Dictionary< string, string >( );

		public
		Enum GetEnum( string index )
		{
			return enumPropertys[ index ];
		}

		public
		PropertyDecorator<TValue> Set(string index, Enum property)
		{
			enumPropertys[ index ] = property;
			return this;
		}

		public
		bool GetBool( string index )
		{
			if ( !boolPropertys.ContainsKey( index ) )
			{
				return false;
			}
			return boolPropertys[ index ];
		}

		public
		PropertyDecorator<TValue>  Set(string index, bool property)
		{
			boolPropertys[ index ] = property;
			return this;
		}

		public
		double GetDouble( string index )
		{
			return doublePropertys[ index ];
		}

		public
		PropertyDecorator<TValue> Set(string index, double property)
		{
			doublePropertys[ index ] = property;
			return this;
		}

		public
		string GetString( string index )
		{
			if ( stringPropertys.ContainsKey( index ) )
			{
				return stringPropertys[ index ];
			}
			return string.Empty;
		}

		public
		PropertyDecorator<TValue> Set(string index, string property)
		{
			stringPropertys[ index ] = property;
			return this;
		}

		public
		TValue Value { get; private set; }

		public
		PropertyDecorator( TValue value )
		{
			Value = value;
		}
	}
}

