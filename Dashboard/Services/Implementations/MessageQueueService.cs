using System;
using System.Threading.Tasks;
using Dashboard.Models;
using Dashboard.Services.Interfaces;
using Azure.Messaging.ServiceBus;

namespace Dashboard.Services.Implementations;

public class MessageQueueService : IMessageQueueService, IAsyncDisposable
{
    private bool _isRunning = false;
    private readonly ServiceBusClient _client = new(Constants.ConnectionString);
    private ServiceBusReceiver _receiver;
    public event EventHandler<SoilMoisture> DataReceived;
    
    public void Connect() => _receiver = _client.CreateReceiver(Constants.QueueName);

    public async Task Disconnect()
    {
        _isRunning = false;
        await DisposeAsync();
    }

    public async Task EnableDataCollection()
    {
        _isRunning = true;
        while (_isRunning)
        {
            var message = await _receiver.ReceiveMessageAsync();
        var body = message.Body.ToString();
        Console.WriteLine($"Body: {body}");

        try
        {
            var soilMoisture = System.Text.Json.JsonSerializer.Deserialize<SoilMoisture>(body);
            // Console.WriteLine($"soil moisture value: {soilMoisture.Value}");
            
            if (soilMoisture is not null)
            {
                    DataReceived?.Invoke(this, soilMoisture);
            }
        }
            catch (Exception)
        {
            Console.WriteLine(ex.Message);
            // No-op
        }

        return Task.CompletedTask;
    }

    private Task HandleErrorReceivedAsync(ProcessErrorEventArgs args)
    {
        DataReceived?.Invoke(this, new()
        {
            Value = 0
        });
        
        return Task.CompletedTask;
    }

    public async Task Connect()
        => _processor.StartProcessingAsync();

    public async Task Disconnect() => await DisposeAsync();

    public async ValueTask DisposeAsync()
    {
        await _receiver.DisposeAsync();
        await _client.DisposeAsync();

        GC.SuppressFinalize(this);
    }
}