using AKindnessCommands.Formating.Container;

namespace AKindnessCommands.Formating
{
	public
	class Tag<TIn>
	: Format<TIn,Tagged<TIn > >
	{
		string tag;

		public
		Tag( string tag )
		{
			this.tag = tag;
		}

		public override
		Tagged< TIn > Apply( TIn input )
		{
			return new Tagged< TIn >( tag, input );
		}

		static
		Tag<TIn> question;

		public static 
		Tag<TIn> AsQuestion
		{
			get
			{
				if ( question == null )
				{
					question = new Tag< TIn >( "?" );
				}
				return question;
			}
		}

		static
		Tag<TIn> information;

		public static 
		Tag<TIn> AsInformation
		{
			get
			{
				if ( information == null )
				{
					information = new Tag< TIn >( ":" );
				}
				return information;
			}
		}

		static
		Tag<TIn> warning;

		public static 
		Tag<TIn> AsWarning
		{
			get
			{
				if ( warning == null )
				{
					warning = new Tag< TIn >( "*" );
				}
				return warning;
			}
		}

		static
		Tag<TIn> error;

		public static 
		Tag<TIn> AsError
		{
			get
			{
				if ( error == null )
				{
					error = new Tag< TIn >( "!" );
				}
				return error;
			}
		}
	}
}