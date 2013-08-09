namespace AKindnessCommands.Formating.Flow
{
	public static
	class ScaleFlow
	{
		public static
		double Scale(this FlowConnector<int> input, int min, int max, double lowerLimit, double upperLimit )
		{
			return ( ( ( upperLimit - lowerLimit ) * ( input.Value - min ) ) / ( max - min ) ) + lowerLimit;
		}

		public static
		double Scale(this FlowConnector<double> input, double min, double max, double lowerLimit, double upperLimit )
		{
			return ( ( ( upperLimit - lowerLimit ) * ( input.Value - min ) ) / ( max - min ) ) + lowerLimit;
		}
	}
}