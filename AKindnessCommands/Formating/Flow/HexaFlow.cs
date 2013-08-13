using System;

namespace AKindnessCommands.Formating.Flow
{
	public static
	class NumberSystemFlow
	{
		public static
		string HexBased(this FlowConnector<int> input )
		{
			return Convert.ToString( input.Value, 16 );
		}

		public static
		string EightBased(this FlowConnector<int> input )
		{
			return Convert.ToString( input.Value, 8 );
		}

		public static
		string BinBased(this FlowConnector<int> input )
		{
			return Convert.ToString( input.Value, 2 );
		}
	}
}