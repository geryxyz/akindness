//AKindnessCommands:
using System;
using System.Collections.Generic;
using AKindnessCommands.EventRelated;
using AKindnessCommands.Model.Emitter;
using AKindnessCommands.Model.Input;
using AKindnessCommands.Model.Output;
using AKindnessCommands.Model.Wrapper;
using AKindnessCommands.Extension;

namespace AKindnessCommands.UserInterface
{
	public
	class CommandExecutor
	{
		Context context = new Context( );
		
		public
		event EventHandler< EventArgs< ExecutionState > > ExecutionStateChanged;

		readonly
		List< Emitter > emitters = new List< Emitter >( );
		

		public
		CommandExecutor( params Emitter[ ] emitters )
		{
			this.emitters = new List< Emitter >( emitters );
		}

		void context_ExecutionStateChanged( object sender, EventArgs<ExecutionState> e )
		{
			ExecutionStateChanged.Raise( this, e );
		}

		private
		bool isRunning = true;

		public
		void ExecutionCycle( Context currentContext )
		{
			context = currentContext;
			context.NewOutputReceived += context_NewOutputReceived;
			context.InputRefreshed += context_InputRefreshed;
			context.NewInputReceived += context_NewInputReceived;
			context.ExecutionStateChanged += context_ExecutionStateChanged;
			context.KeyPressed += new EventHandler<EventArgs<ConsoleKeyInfo>>( context_KeyPressed );

			Console.CursorVisible = false;

			currentContext.Define(
				"exit",
				( _invocation, _context ) =>
				{
					PropertyDecorator< string > _message = new PropertyDecorator< string >( "Shutting down execution cycle." );
					_message.Set( "sync", true );
					_message.Set( "language", "english" );
					_context.SystemOutput.Enqueue(
						new CommandOutput(
							OutputLevel.Information,
							_message,
							DateTime.Now ) );
					isRunning = false;
				} );

			while ( isRunning )
			{
				context.State = ExecutionState.Waiting;
				currentContext.MainInput.Enqueue( );
				context.State = ExecutionState.Idle;
			}
		}

		void context_KeyPressed( object sender, EventArgs<ConsoleKeyInfo> e )
		{
			foreach ( Emitter _emitter in emitters )
			{
				_emitter.KeyPressed( e.Value );
			}
		}

		void context_InputRefreshed( object sender, EventRelated.EventArgs<InputCollector> e )
		{
			foreach ( var _emitter in emitters )
			{
				if ( _emitter.IsSensibleFor( e.Value ) )
				{
					PropertyDecorator< string > _glint = new PropertyDecorator< string >( e.Value.Glint( ) );
					_glint.Set( "complete", false );
					_emitter.EmitSingle( _glint );
				}
			}
		}

		void context_NewInputReceived( object sender, EventRelated.EventArgs<InputCollector> e )
		{
			foreach ( var _emitter in emitters )
			{
				if ( _emitter.IsSensibleFor( e.Value ) )
				{
					foreach ( string _currentInput in e.Value.PeekAll( ) )
					{
						PropertyDecorator< string > _wrap = new PropertyDecorator< string >( _currentInput );
						_wrap.Set( "complete", true );
						_emitter.EmitSingle( _wrap );
					}
				}
			}

			while ( e.Value.Any( ) )
			{
				context.Execute( e.Value.Dequeue( ) );
			}
		}

		void context_NewOutputReceived( object sender, EventRelated.EventArgs<OutputCollector> e )
		{
			while ( e.Value.Any( ) )
			{
				CommandOutput _currentOutput = e.Value.Dequeue( );
				foreach ( var _emitter in emitters )
				{
					if ( _emitter.IsSensibleFor( e.Value ) )
					{
						_emitter.EmitSingle( _currentOutput );
					}
				}
			}
		}
	}
}

