using Microsoft.Azure.Devices.Client;
using System.Text.Json;
using System.Text;

namespace SoilMoistureSensor;

public class IoTHubService
{
	private readonly DeviceClient _deviceClient;

	public IoTHubService(string connectionString)
	{
		_deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Amqp); // use AMQP
	}

	public async Task SendAsync<IIoTHubMessage>(IIoTHubMessage message)
	{
		string serializedMessage = JsonSerializer.Serialize(message);
		Message iotHubMessage = new Message(Encoding.UTF8.GetBytes(serializedMessage));

		await _deviceClient.SendEventAsync(iotHubMessage);
	}
}