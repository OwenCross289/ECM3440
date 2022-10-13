using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Models;

namespace Dashboard.Services.Interfaces;

public interface IMessageQueueService
{
    void Connect();
    Task Disconnect();
    Task EnableDataCollection();

    public event EventHandler<SoilMoisture> DataReceived;
}