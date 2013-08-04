//AKindnessCommands:
using System;
using AKindnessCommands.Model.Wrapper;

namespace AKindnessCommands.Extension
{
	public static
	class StringExtension
	{
		public static
		string Format( this string self, params object[] parameters)
		{
			return string.Format( self, parameters );
		}

		public static
		void ColorWrite( this string text, ConsoleColor textColor, ConsoleColor backgroundColor = ConsoleColor.Black )
		{
			try
			{
				ConsoleColor _foregroundBackUp = Console.ForegroundColor;
				ConsoleColor _backgroundBackUp = Console.BackgroundColor;

				Console.ForegroundColor = textColor;
				Console.BackgroundColor = backgroundColor;
				Console.Write( text );
				
				Console.ForegroundColor = _foregroundBackUp;
				Console.BackgroundColor = _backgroundBackUp;
			}
			catch ( Exception )
			{
				Console.Write( text );
			}
		}

		public static
		void ColorWriteLine( this string text, ConsoleColor textColor, ConsoleColor backgroundColor = ConsoleColor.Black )
		{
			text.ColorWrite( textColor, backgroundColor );
			Console.WriteLine( );
		}

		public static
		PropertyDecorator<string> Decorat(this string self)
		{
			PropertyDecorator< string > _decorated = new PropertyDecorator< string >( self );
			return _decorated;
		}

		public static
		PropertyDecorator<string> Decorat(this string self,string key,Enum value)
		{
			PropertyDecorator< string > _decorated = new PropertyDecorator< string >( self );
			_decorated.Set( key, value );
			return _decorated;
		}

		public static
		PropertyDecorator<string> Decorat(this string self,string key,bool value)
		{
			PropertyDecorator< string > _decorated = new PropertyDecorator< string >( self );
			_decorated.Set( key, value );
			return _decorated;
		}

		public static
		PropertyDecorator<string> Decorat(this string self,string key,double value)
		{
			PropertyDecorator< string > _decorated = new PropertyDecorator< string >( self );
			_decorated.Set( key, value );
			return _decorated;
		}

		public static
		PropertyDecorator<string> Decorat(this string self,string key,string value)
		{
			PropertyDecorator< string > _decorated = new PropertyDecorator< string >( self );
			_decorated.Set( key, value );
			return _decorated;
		}

		public static
		PropertyDecorator<string> DecoratAsEnglish(this string self)
		{
			PropertyDecorator< string > _decorated = new PropertyDecorator< string >( self );
			_decorated.Set( "language", "english" );
			return _decorated;
		}

		public static
		PropertyDecorator<string> DecoratAsDoNotRead(this string self)
		{
			PropertyDecorator< string > _decorated = new PropertyDecorator< string >( self );
			_decorated.Set( "do not read", true );
			return _decorated;
		}

		public static
		string CropIf(this string self, int? width)
		{
			if ( width.HasValue &&
				width < self.Length)
			{
				return self.Substring( 0, width.Value );
			}
			return self;
		}
	}
}

