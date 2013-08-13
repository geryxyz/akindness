using AKindnessCommands.Formating.Container;

namespace AKindnessCommands.Formating.Flow
{
	public static
	class PlacedFlow
	{
		public static
		Placed<TValue > Placed<TValue>(this FlowConnector<TValue> input, int x, int y)
		{
			return new Placed< TValue >( input.Value, x, y );
		}
	}
}