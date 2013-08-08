namespace AKindnessCommands.Formating
{
	public
	class NormalizeDouble
	: ScaleDouble
	{
		public NormalizeDouble( double min, double max )
		: base( 0, 1, min, max ) {}
	}
}