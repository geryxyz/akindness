namespace AKindnessCommands.Formating.Flow
{
	public static
	class FormatFlow
	{
		public static
		string Format(this FlowConnector<string> input, params object[] parameters)
		{
			return string.Format( input.Value, parameters );
		}
	}
}