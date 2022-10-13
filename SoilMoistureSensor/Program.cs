//Console.WriteLine();

//var client = DeviceClient.CreateFromConnectionString("HostName=ECM3440.azure-devices.net;DeviceId=soil-moisture-sensor;SharedAccessKey=VGlo7rYmMZJVcVaJIehiOgF0QnUCmh3FHFxfpu9RukY=");

// IOT connection
// Don't need CounterFit - can just send any data

// Connection to IOT
// Create client for IOT & connect

Console.WriteLine("Connecting");
var IoTHubService = new IoTHubService("HostName=ECM3440.azure-devices.net;DeviceId=soil-moisture-sensor;SharedAccessKey=VGlo7rYmMZJVcVaJIehiOgF0QnUCmh3FHFxfpu9RukY=");
Console.WriteLine("Connected");

while (true) 
{ 
    var message = new SoilMoistureStatus { Value = 10 };
    await IoTHubService.SendAsync(message);
    Console.WriteLine($"Soil Moisture: {message.Value}");
    Thread.Sleep(10000);
}

// Test project for soil moisture sensor
// Test project for dashboard
// Dashboard project