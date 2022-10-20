using SoilMoistureSensor;

public class SoilMoistureStatus : IIoTHubMessage
{
	public double Value { get; init; }
}