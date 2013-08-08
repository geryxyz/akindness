namespace AKindnessCommands.Formating
{
	public
	class NormalizeInt
	: ScaleInt
	{
		public NormalizeInt( double min, double max )
		: base( 0, 1, min, max ) {}
	}
}