namespace AKindnessCommands.Formating
{
	public
	class ScaleInt
	: Format<int,double>
	{
		double upperLimit;
		double lowerLimit;
		double min;
		double max;

		public
		ScaleInt( double lowerLimit, double upperLimit, double min, double max )
		{
			this.upperLimit = upperLimit;
			this.lowerLimit = lowerLimit;
			this.min = min;
			this.max = max;
		}

		public override
		double Apply( int input )
		{
			return ( ( ( upperLimit - lowerLimit ) * ( input - min ) ) / ( max - min ) ) + lowerLimit;
		}
	}
}