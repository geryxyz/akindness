using AKindnessCommands.Formating.Container;

namespace AKindnessCommands.Formating
{
	public
	class Tag<TTag,TIn>
	: Format<TIn,Tagged<TTag,TIn > >
	{
		TTag tag;

		public
		Tag( TTag tag )
		{
			this.tag = tag;
		}

		public override
		Tagged<TTag, TIn > Apply( TIn input )
		{
			return new Tagged<TTag, TIn >( tag, input );
		}

		static
		Tag<string,TIn> question;

		public static 
		Tag<string,TIn> AsQuestion
		{
			get
			{
				if ( question == null )
				{
					question = new Tag<string, TIn >( "?" );
				}
				return question;
			}
		}

		static
		Tag<string,TIn> information;

		public static 
		Tag<string,TIn> AsInformation
		{
			get
			{
				if ( information == null )
				{
					information = new Tag<string, TIn >( ":" );
				}
				return information;
			}
		}

		static
		Tag<string,TIn> warning;

		public static 
		Tag<string,TIn> AsWarning
		{
			get
			{
				if ( warning == null )
				{
					warning = new Tag<string, TIn >( "*" );
				}
				return warning;
			}
		}

		static
		Tag<string,TIn> error;

		public static 
		Tag<string,TIn> AsError
		{
			get
			{
				if ( error == null )
				{
					error = new Tag<string, TIn >( "!" );
				}
				return error;
			}
		}
	}

	public static partial
	class As
	{
		public static
		Tag< TTag, string > Tag< TTag >( TTag tag )
		{
			return new Tag< TTag, string >( tag );
		}
	}
}