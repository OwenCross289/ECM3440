using System.Diagnostics.CodeAnalysis;
using SoilMoistureSensor;

[ExcludeFromCodeCoverage]
class Program
{
    public async static Task Main(string[] args)
    {
        Console.WriteLine("Connecting");
        var IoTHubService = new IoTHubService("HostName=ECM3440.azure-devices.net;DeviceId=soil-moisture-sensor;SharedAccessKey=VGlo7rYmMZJVcVaJIehiOgF0QnUCmh3FHFxfpu9RukY=");
        Console.WriteLine("Connected");
        var rand = new Random();

        while (true)
        {
            var message = new SoilMoistureStatus { Value = rand.NextDouble() * 1023 };
            await IoTHubService.SendAsync(message);
            Console.WriteLine($"Soil Moisture: {message.Value}");
            Thread.Sleep(10000);
        }
    }
}