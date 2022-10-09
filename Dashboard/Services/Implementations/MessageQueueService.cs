using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Models;
using Dashboard.Services.Interfaces;
using Azure.Messaging.ServiceBus;

namespace Dashboard.Services.Implementations;

public class MessageQueueService : IMessageQueueService, IAsyncDisposable
{
    private const string ConnectionString =
        "Endpoint=sb://ecm3440.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=BbsLB3LdHT3NuMjh4NBV5jeaKb7lOA8TTkYEIi25wuU=";

    private const string QueueName = "ecm3440-telemetry-queue";

    private readonly ServiceBusClient _client = new(ConnectionString);

    private ServiceBusReceiver _receiver;

    private bool _isTransmitting;
    private bool _isConnected;
    
    public void Connect()
    {
        _receiver = _client.CreateReceiver(QueueName);
        _isConnected = true;
    }

    public async Task Disconnect()
    {
        _isTransmitting = false;
        _isConnected = false;
        await DisposeAsync();
    }

    public async Task<SoilMoisture> GetData()
    {
        _isTransmitting = true;
            var message = await _receiver.ReceiveMessageAsync();
            var body = message.Body.ToString();
            Console.WriteLine(body);
            var soilMoisture = new SoilMoisture
            {
                Value = 0
            };

            try
            {
                soilMoisture = System.Text.Json.JsonSerializer.Deserialize<SoilMoisture>(body);
                Console.WriteLine(soilMoisture.Value);
            }
            catch (Exception)
            {
                // No-op
            }

            return soilMoisture;
        }

    public async ValueTask DisposeAsync()
    {
        await _receiver.DisposeAsync();
        await _client.DisposeAsync();
        
        GC.SuppressFinalize(this);
    }
}