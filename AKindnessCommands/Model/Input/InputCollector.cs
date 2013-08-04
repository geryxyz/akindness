//AKindnessCommands:
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AKindnessCommands.Extension;
using AKindnessCommons.EventRelated;
using AKindnessCommons.Extension;

namespace AKindnessCommands.Model.Input
{
	public abstract
	class InputCollector
	{
		public
		string Name { get; private set; }

		protected
		InputCollector( string name )
		{
			Name = name;
		}

		protected readonly
		Queue< string > InputLines = new Queue< string >( );
		protected readonly
		StringBuilder CurrentLine = new StringBuilder( );

		public
		String Dequeue()
		{
			return InputLines.Dequeue( );
		}

		public
		IEnumerable< string > PeekAll()
		{
			return InputLines.AsEnumerable( );
		}

		/// <summary>
		/// Get the next finished input line without remove it.
		/// </summary>
		/// <returns>Next input finished line</returns>
		public
		string Peek()
		{
			return InputLines.Peek( );
		}

		/// <summary>
		/// Get the current input line, even before the user finished it.
		/// </summary>
		/// <returns></returns>
		public
		string Glint()
		{
			return CurrentLine.ToString( );
		}

		public abstract
		void Enqueue();

		public
		void AddRange(IEnumerable<string> inputs)
		{
			foreach ( string _input in inputs )
			{
				InputLines.Enqueue( _input );
			}
			NewInputLineAdded.Raise( this, EventArgs.Empty );
		}

		public
		event EventHandler< EventArgs< ConsoleKeyInfo > > KeyPressed;

		protected
		void onKeyPressed( EventArgs< ConsoleKeyInfo > e )
		{
			EventHandler< EventArgs< ConsoleKeyInfo > > _handler = KeyPressed;
			if ( _handler != null )
			{
				_handler( this, e );
			}
		}

		public
		event EventHandler CurrentLineChanged;

		protected
		void onCurrentLineChanged( EventArgs e )
		{
			EventHandler _handler = CurrentLineChanged;
			if ( _handler != null )
			{
				_handler( this, e );
			}
		}

		public
		event EventHandler NewInputLineAdded;

		protected
		void onNewInputLineAdded( EventArgs e )
		{
			EventHandler _handler = NewInputLineAdded;
			if ( _handler != null )
			{
				_handler( this, e );
			}
		}

		public
		bool Any( )
		{
			return InputLines.Any( );
		}
	}
}

