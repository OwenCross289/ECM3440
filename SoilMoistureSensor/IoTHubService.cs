using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;


// Service class to communicate with the Azure IoT Hub
public class IoTHubService
{
	private readonly DeviceClient _deviceClient;

	// Creates the service class instance with your IoTHub connection string and your unique device id
	public IoTHubService(string connectionString)
	{
		_deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Amqp); // use AMQP
	}

	// sends messages to IoT Hub - generic constraint to send only specific message types
	public async Task SendAsync<IIoTHubMessage>(IIoTHubMessage message)
	{
		string serializedMessage = JsonConvert.SerializeObject(message);
		Message iotHubMessage = new Message(Encoding.UTF8.GetBytes(serializedMessage));

		await _deviceClient.SendEventAsync(iotHubMessage);
	}
}

// Connection to IOT
// Create client for IOT & connect

// Test project for soil moisture sensor
// Test project for dashboard
// Dashboard project