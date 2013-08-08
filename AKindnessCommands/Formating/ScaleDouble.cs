namespace AKindnessCommands.Formating
{
	public
	class ScaleDouble
	: Format<double,double>
	{
		double upperLimit;
		double lowerLimit;
		double min;
		double max;

		public
		ScaleDouble( double lowerLimit, double upperLimit, double min, double max )
		{
			this.upperLimit = upperLimit;
			this.lowerLimit = lowerLimit;
			this.min = min;
			this.max = max;
		}

		public override
		double Apply( double input )
		{
			return ( ( ( upperLimit - lowerLimit ) * ( input - min ) ) / ( max - min ) ) + lowerLimit;
		}
	}
}