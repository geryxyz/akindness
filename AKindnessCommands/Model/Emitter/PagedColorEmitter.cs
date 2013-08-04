//AKindnessCommands:
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using AKindnessCommands.Model.Output;
using AKindnessCommands.Extension;

namespace AKindnessCommands.Model.Emitter
{
	public
	class PagedColorEmitter
	: ColorEmitter
	{
		List< CommandOutput > tempPage =
			new List< CommandOutput >( );
		Dictionary< DateTime, List< CommandOutput > > pages =
			new Dictionary< DateTime, List< CommandOutput > >( );
		DateTime? currentPageIndex = null;

		public
		PagedColorEmitter( params Cursor.Cursor[ ] cursors )
		: base( cursors )
		{
			beforClearOutput += PagedColorEmitter_beforClearOutput;
		}

		void PagedColorEmitter_beforClearOutput( object sender, EventArgs e )
		{
			storePage( );
		}

		void storePage( )
		{
			if ( tempPage.Any( ) )
			{
				DateTime _key = DateTime.Now;
				pages[ _key ] = tempPage;
				tempPage = new List< CommandOutput >( );
			}
		}

		readonly
		SpeechSynthesizer mouth = new SpeechSynthesizer( );

		public override
		void KeyPressed( ConsoleKeyInfo key )
		{
			if ( key.Modifiers == 0 )
			{
				KeyValuePair< DateTime, List< CommandOutput > > _page;
				switch ( key.Key )
				{
					case ConsoleKey.LeftArrow:
						//mouth.Speak( "Left arrow key pressed" );
						if ( currentPageIndex == null )
						{
							//mouth.Speak( "No page loaded yet." );
							if( pages.Any( ) )
							{
								//mouth.Speak( "There is some page stored already." );
								_page = pages.Last( );
								//mouth.Speak( "Load last stored page." );
								loadPage( _page );
								//mouth.Speak( "Store temporary page." );
								storePage( );
							}
						}
						else
						{
							//mouth.Speak( "There is some page loaded." );
							IOrderedEnumerable< DateTime > _sortedKey = pages.Keys.OrderBy( _k => _k.Ticks );
							var _currentKeyIndex = currentKeyIndex( _sortedKey );
							//mouth.Speak( "The current page index is {0}".Format( currentPageIndex ) );
							//mouth.Speak(
							//	"Current key index check: {0}".Format(
							//		currentPageIndex == _sortedKey.ElementAt( _currentKeyIndex ) ) );
							//mouth.Speak( "The current key index is {0}".Format( _currentKeyIndex ) );
							if ( _currentKeyIndex>0 )
							{
								//mouth.Speak( "Getting previous page index." );
								DateTime _preKey = _sortedKey.ElementAt( --_currentKeyIndex );
								//mouth.Speak( "Load previous page." );
								_page = new KeyValuePair< DateTime, List< CommandOutput > >(
									_preKey,
									pages[ _preKey ] );
								loadPage(
									_page );
							}
						}
						//mouth.Speak( "Left arrow processing done." );
						displayPageIndicator( );
						break;
					case ConsoleKey.RightArrow:
						if ( currentPageIndex == null )
						{
							if( pages.Any( ) )
							{
								_page = pages.First( );
								loadPage( _page );
								storePage( );
							}
						}
						else
						{
							IOrderedEnumerable< DateTime > _sortedKey = pages.Keys.OrderBy( _k => _k.Ticks );
							var _currentKeyIndex = currentKeyIndex( _sortedKey );
							if ( _currentKeyIndex<pages.Count-1 )
							{
								DateTime _preKey = _sortedKey.ElementAt( ++_currentKeyIndex );
								_page = new KeyValuePair< DateTime, List< CommandOutput > >(
									_preKey,
									pages[ _preKey ] );
								loadPage(
									_page );
							}
						}
						displayPageIndicator( );
						break;
				}
			}
		}

		int currentKeyIndex( IOrderedEnumerable< DateTime > _sortedKey )
		{
			int _currentKeyIndex = 0;
			for ( ;
				_sortedKey.ElementAt( _currentKeyIndex ) != currentPageIndex;
				_currentKeyIndex++ ) {}
			return _currentKeyIndex;
		}

		void loadPage( KeyValuePair< DateTime, List< CommandOutput > > _page )
		{
			clear( );
			getCursorBy( "main" ).Reset( );
			foreach ( CommandOutput _output in _page.Value )
			{
				base.EmitSingle( _output );
			}
			currentPageIndex = _page.Key;
		}

		public override
		void EmitSingle( CommandOutput output )
		{
			base.EmitSingle( output );
			tempPage.Add( output );

			displayPageIndicator( );
		}

		void displayPageIndicator( )
		{
			Cursor.Cursor _pageCursor = getCursorBy( "page" );
			Console.SetCursorPosition( _pageCursor.Position.X, _pageCursor.Position.Y );
			IOrderedEnumerable< DateTime > _sortedKey = pages.Keys.OrderBy( _k => _k.Ticks );
			foreach ( Rectangle _clearingRegion in _pageCursor.ClearingRegions )
			{
				clearRectangle( _clearingRegion );
			}
			_pageCursor.Reset( );
			if ( pages.Any( ) )
			{
				foreach ( DateTime _pageIndex in _sortedKey )
				{
					if ( _pageIndex == currentPageIndex )
					{
						"[+]".ColorWrite( ConsoleColor.Black, ConsoleColor.Red );
					}
					else
					{
						"---".ColorWrite( ConsoleColor.Red );
					}
				}
			}
			else
			{
				"( )".ColorWrite( ConsoleColor.Red );
			}
		}
	}
}

