namespace AKindnessCommands.Formating
{
	public
	interface ISpeakable
	{
		ConcurrentCommunicable SayAsync( );

		ConcurrentCommunicable SaySync( );
	}
}