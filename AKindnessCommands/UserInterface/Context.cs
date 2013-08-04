//AKindnessCommands:
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using AKindnessCommands.Model;
using AKindnessCommands.Model.Input;
using AKindnessCommands.Model.Output;
using AKindnessCommands.Extension;
using AKindnessCommands.Model.Wrapper;
using AKindnessCommons.EventRelated;
using AKindnessCommons.Extension;

namespace AKindnessCommands.UserInterface
{
	public class Context
	{
		readonly
		Dictionary< string, Command > commands =
			new Dictionary< string, Command >( );
		public readonly
		OutputCollector MainOutput = new OutputCollector( "main" );
		public readonly
		OutputCollector SystemOutput = new OutputCollector( "system" );
		readonly
		Dictionary< string, OutputCollector > subCollectors =
			new Dictionary< string, OutputCollector >( );
		public readonly
		InputCollector MainInput = new ConsoleInputCollector( "main" );

		public
		bool SuppressExceptions { get; set; }

		public
		event EventHandler< EventArgs< ExecutionState > > ExecutionStateChanged;
		
		ExecutionState state;
		public
		ExecutionState State
		{
			get
			{
				return state;
			}
			set
			{
				state = value;
				ExecutionStateChanged.Raise( this, new EventArgs< ExecutionState >( value ) );
			}
		}

		public
		Context( )
		{
			SuppressExceptions = true;

			MainOutput.NewOutputReceived += collector_NewOutputReceived;
			SystemOutput.NewOutputReceived += collector_NewOutputReceived;

			MainInput.NewInputLineAdded += collector_NewInputReceived;
			MainInput.CurrentLineChanged += MainInput_CurrentLineChanged;
			MainInput.KeyPressed += MainInput_KeyPressed;

			Define(
				"do nothing",
				( _invocation, _context ) =>
				{
					#region
					PropertyDecorator< string > _message = new PropertyDecorator< string >( "I didn't do anything." );
					_message.Set( "language", "english" );
					_context.MainOutput.Enqueue(
						new CommandOutput(
							OutputLevel.Information,
							_message,
							DateTime.Now ) );
					#endregion
				} );

			Define( "help",
				( _invocation, _context ) =>
				{
					#region
					PropertyDecorator< string > _message =
						new PropertyDecorator< string >(
							"There is {0} command defined in this context.".Format( _context.commands.Count( ) ) );
					_message.Set( "language", "english" );
					_context.MainOutput.Enqueue(
						new CommandOutput(
							OutputLevel.Information,
							_message,
							DateTime.Now ) );

					_message =
						new PropertyDecorator< string >(
							"The first 10 command defined in this context." );
					_message.Set( "language", "english" );
					_context.MainOutput.Enqueue(
						new CommandOutput(
							OutputLevel.Information,
							_message,
							DateTime.Now ) );

					var _orderedCommand = _context.commands.OrderBy( _e => _e.Value.FingerPrint );
					foreach ( KeyValuePair< string, Command > _commandDefinition in _orderedCommand.Take( 10 ) )
					{
						_context.MainOutput.Enqueue( _commandDefinition.Value.FingerPrint.DecoratAsEnglish( ) );
					}

					_message =
						new PropertyDecorator< string >(
							"Use command ,,list commands from::th to::th'' for more." );
					_message.Set( "language", "english" );
					_context.MainOutput.Enqueue(
						new CommandOutput(
							OutputLevel.Information,
							_message,
							DateTime.Now ) );

					_message =
						new PropertyDecorator< string >(
							"Use command ,,describe ::command'' for help about commands." );
					_message.Set( "language", "english" );
					_context.MainOutput.Enqueue(
						new CommandOutput(
							OutputLevel.Information,
							_message,
							DateTime.Now ) );
					#endregion
				} );

			Define( "list commands from::th to::th",
				( _invocation, _context ) =>
				{
					#region
					int _from = int.Parse( _invocation[ "from:th" ].Value );
					int _to = int.Parse( _invocation[ "to:th" ].Value );

					PropertyDecorator< string > _message =
						new PropertyDecorator< string >(
							"Commands from {0} to {1} are the followings.".Format( _from, _to ) );
					_message.Set( "language", "english" );
					_context.MainOutput.Enqueue(
						new CommandOutput(
							OutputLevel.Information,
							_message,
							DateTime.Now ) );

					var _orderedCommand = _context.commands.OrderBy( _e => _e.Value.FingerPrint );
					StringBuilder _listOfCommands = new StringBuilder( );
					for ( int _index = _from; _index < _to; _index++ )
					{
						_context.MainOutput.Enqueue(
							_orderedCommand.ElementAt( _index ).Value.FingerPrint.DecoratAsEnglish( ) );
					}
					#endregion
				} );
				
			Define(
				"execute from::",
				( _invocation, _context ) =>
				{
					#region
					string _path = _invocation[@"^from$:"].Value;
					var _inputLines = loadFile( _path );
					MainOutput.Enqueue(
						"Totaly {0} input lines loaded. Start execution now.".Format( _inputLines.Count( ) ).DecoratAsEnglish( ) );
					MainInput.AddRange( _inputLines );
					#endregion
				} );
			Define(
				"wait for::milliseconds",
				( _invocation, _context ) =>
				{
					#region
					int _timeout = int.Parse( _invocation[ @"^for$:^milliseconds$" ].Value );
					_context.MainOutput.Enqueue(
						"Waiting for {0} milliseconds.".Format( _timeout ).DecoratAsEnglish( ) );
					Thread.Sleep( _timeout );
					#endregion
				} );
			Define(
				"label as::",
				( _invocation, _context ) =>
				_context.MainOutput.Enqueue(
					_invocation[ @"^as$:" ].Value.DecoratAsEnglish( ),
					OutputLevel.Note ) );
		}

		private
		IEnumerable< string > loadFile( string path )
		{
			List< string > _inputLines = new List< string >( );
			using ( StreamReader _input = new StreamReader( path ) )
			{
				MainOutput.Enqueue(
					"File open from {0}".Format(
						( object )path ).DecoratAsEnglish( ) );
				while ( !_input.EndOfStream )
				{
					string _currentLine = _input.ReadLine( );
					if ( !string.IsNullOrWhiteSpace( _currentLine ) )
					{
						if ( _currentLine.StartsWith( "-> " ) )
						{
							MainOutput.Enqueue("Include line found.".DecoratAsEnglish( ) );
							string _path = _currentLine.Substring( 3 );
							_inputLines.AddRange( loadFile( _path ) );
						}
						else
						{
							_inputLines.Add(
								"label as:{0}".Format(
									( object )_currentLine.Replace( " ", "~s" ).Replace( ":", "~c" ) ) );
							_inputLines.Add( _currentLine );
						}
					}
				}
				MainOutput.Enqueue(
					"{0} lines loaded".Format(
						_inputLines.Count( ) ).DecoratAsEnglish( ) );
			}
			return _inputLines;
		}

		void MainInput_KeyPressed( object sender, EventArgs<ConsoleKeyInfo> e )
		{
			KeyPressed.Raise( this, e );
		}

		void MainInput_CurrentLineChanged( object sender, EventArgs e )
		{
			InputRefreshed.Raise( this,new EventArgs< InputCollector >( sender as InputCollector ) );
		}

		void collector_NewInputReceived( object sender, EventArgs e )
		{
			NewInputReceived.Raise( this, new EventArgs< InputCollector >( sender as InputCollector ) );
		}

		public
		void AttachSubCollector( OutputCollector collector )
		{
			if(collector.Name != "main")
			{
				collector.NewOutputReceived += collector_NewOutputReceived;
				subCollectors[ collector.Name ] = collector;
			}
			else
			{
				throw new NotImplementedException( );
			}
		}

		void collector_NewOutputReceived( object sender, EventArgs e )
		{
			NewOutputReceived.Raise( this, new EventArgs< OutputCollector >( sender as OutputCollector ) );
		}

		public
		event EventHandler< EventArgs< OutputCollector > > NewOutputReceived;
		public
		event EventHandler< EventArgs< InputCollector > > NewInputReceived;
		public
		event EventHandler< EventArgs< InputCollector > > InputRefreshed;
		public
		event EventHandler< EventArgs< ConsoleKeyInfo > > KeyPressed;

		public
		void Define(string fingerPrint, Action<CommandInvocation, Context> body )
		{
			Command _command = new Command( fingerPrint, body );
			commands[ _command.FingerPrint ] = _command;
		}

		public
		void Execute(string userInput)
		{
			State = ExecutionState.Running;
			CommandInvocation _currentInvocation = new CommandInvocation( userInput );
			if ( commands.ContainsKey( _currentInvocation.FingerPrint ) )
			{
				try
				{
					commands[ _currentInvocation.FingerPrint ].Execute( _currentInvocation, this );
				}
				catch(Exception _exc)
				{
					MainOutput.Enqueue( _exc.Message.Decorat( "language", "english" ), OutputLevel.Error );
					if ( !SuppressExceptions )
					{
						throw;
					}
				}
			}
			else
			{
				PropertyDecorator< string > _message =
					new PropertyDecorator< string >(
						"The command-fingerprint \"{0}\" is undefined in the current context.".Format( ( object )userInput ) );
				_message.Set( "language", "english" );
				SystemOutput.Enqueue(
					new CommandOutput(
						OutputLevel.Error,
						_message,
						DateTime.Now ) );
			}
			State = ExecutionState.Idle;
		}
	}
}

