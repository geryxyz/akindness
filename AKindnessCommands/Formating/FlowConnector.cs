namespace AKindnessCommands.Formating
{
	public
	class FlowConnector<TIn>
	{
		public
		TIn Value { get; private set; }

		public
		FlowConnector( TIn value )
		{
			Value = value;
		}
	}
}