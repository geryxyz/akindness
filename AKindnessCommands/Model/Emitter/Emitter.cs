//AKindnessCommands:
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AKindnessCommands.Model.Input;
using AKindnessCommands.Model.Output;
using AKindnessCommons.Wrapper;
using Wintellect.PowerCollections;

namespace AKindnessCommands.Model.Emitter
{
	public abstract
	class Emitter
	{
		protected
		Emitter( params Cursor.Cursor[] cursors )
		{
			this.cursors = new List< Cursor.Cursor >( cursors );
		}

		readonly
		Set< string > outputSensors = new Set< string >( );
		readonly
		Set< string > inputSensors = new Set< string >( );
		readonly
		List< Cursor.Cursor > cursors = new List< Cursor.Cursor >( );
		protected
		Cursor.Cursor getCursorBy( string name )
		{
			return cursors.First( _c => _c.Name == name );
		}

		public
		void BeSensibleFor(OutputCollector collector)
		{
			outputSensors.Add( collector.Name );
		}

		public
		void BeSensibleFor(InputCollector collector)
		{
			inputSensors.Add( collector.Name );
		}

		public
		bool IsSensibleFor(OutputCollector collector)
		{
			return outputSensors.Contains( collector.Name );
		}

		public bool IsSensibleFor( InputCollector collector )
		{
			return inputSensors.Contains( collector.Name );
		}

		public abstract
		void EmitSingle( CommandOutput output);

		public abstract
		void EmitSingle( PropertyDecorator< string > input );

		IEnumerable< Rectangle > clearingRegions
		{
			get
			{
				List< Rectangle > _rectangles = new List< Rectangle >( );
				foreach ( Cursor.Cursor _cursor in cursors )
				{
					_rectangles.AddRange( _cursor.ClearingRegions );
				}
				return _rectangles;
			}
		}

		protected abstract
		void clearRectangle( Rectangle region );

		protected
		void clear()
		{
			foreach ( Rectangle _rectangle in clearingRegions )
			{
				clearRectangle( _rectangle );
			}
		}

		public virtual
		void KeyPressed( ConsoleKeyInfo key ) {}
	}
}

