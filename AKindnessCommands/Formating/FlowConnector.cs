namespace AKindnessCommands.Formating
{
	public
	class FlowConnector<TIn>
	: IFlowConnector
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