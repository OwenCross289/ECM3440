using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Models;

namespace Dashboard.Services.Interfaces;

public interface IMessageQueueService
{
    void Connect();
    Task Disconnect();
    Task<SoilMoisture> GetData();
}