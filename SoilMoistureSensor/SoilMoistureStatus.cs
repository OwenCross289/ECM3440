//Console.WriteLine();

//var client = DeviceClient.CreateFromConnectionString("HostName=ECM3440.azure-devices.net;DeviceId=soil-moisture-sensor;SharedAccessKey=VGlo7rYmMZJVcVaJIehiOgF0QnUCmh3FHFxfpu9RukY=");

// IOT connection
// Don't need CounterFit - can just send any data


// Interface to provide generic constraints
// Message class for temperature values
using SoilMoistureSensor;

public class SoilMoistureStatus : IIoTHubMessage
{
	public double Value { get; set; }
}

// Connection to IOT
// Create client for IOT & connect

// Test project for soil moisture sensor
// Test project for dashboard
// Dashboard project