using Dashboard.Models;
using Dashboard.Services.Interfaces;
using Azure.Messaging.ServiceBus;

namespace Dashboard.Services.Implementations;

public class MessageQueueService : IMessageQueueService, IAsyncDisposable
{
    private readonly ServiceBusClient _client = new(Constants.ConnectionString);
    private readonly ServiceBusProcessor _processor;
    
    public event EventHandler<SoilMoisture>? DataReceived;

    public MessageQueueService()
    {
        _processor = _client.CreateProcessor(Constants.QueueName);
        _processor.ProcessMessageAsync += HandleMessageReceivedAsync;
        _processor.ProcessErrorAsync += HandleErrorReceivedAsync;
    }

    private Task HandleMessageReceivedAsync(ProcessMessageEventArgs args)
    {
        var message = args.Message;
        var body = message.Body.ToString();
        Console.WriteLine($"Body: {body}");

        try
        {
            var soilMoisture = System.Text.Json.JsonSerializer.Deserialize<SoilMoisture>(body);
            // Console.WriteLine($"soil moisture value: {soilMoisture.Value}");
            
            if (soilMoisture is not null)
            {
                DataReceived.Invoke(this, soilMoisture);
            }
        }
        catch (Exception ex)
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
        await _processor.StopProcessingAsync();
        _processor.ProcessMessageAsync -= HandleMessageReceivedAsync;
        _processor.ProcessErrorAsync -= HandleErrorReceivedAsync;
        
        await _processor.DisposeAsync();
        await _client.DisposeAsync();

        GC.SuppressFinalize(this);
    }
}