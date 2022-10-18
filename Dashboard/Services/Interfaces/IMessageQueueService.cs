using Dashboard.Models;

namespace Dashboard.Services.Interfaces;

public interface IMessageQueueService
{
    Task Connect();
    Task Disconnect();
    public event EventHandler<SoilMoisture> DataReceived;
}