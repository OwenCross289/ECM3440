using System.Collections.Generic;
using Dashboard.Models;

namespace Dashboard.Services.Interfaces;

public interface IMessageQueueService
{
    void Connect();
    void Disconnect();
    IEnumerable<SoilMoisture> GetData();
}