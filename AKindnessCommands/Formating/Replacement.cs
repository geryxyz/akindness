namespace AKindnessCommands.Formating
{
	public
	class Replacement
	: Format<string,string>
	{
		object[ ] parameters;

		public
		Replacement( params object[] parameters)
		{
			this.parameters = parameters;
		}

		public override
		string Apply( string input )
		{
			return string.Format( input, parameters );
		}
	}
}