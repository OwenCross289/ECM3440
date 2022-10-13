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

            try
            {
                var soilMoisture = System.Text.Json.JsonSerializer.Deserialize<SoilMoisture>(body);
                if (soilMoisture is not null)
                {
                    DataReceived?.Invoke(this, soilMoisture);
                }
            }
            catch (Exception)
            {
                // No-op
            }
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _receiver.DisposeAsync();
        await _client.DisposeAsync();

        GC.SuppressFinalize(this);
    }
}