using System;
using System.Threading;
using Xunit;

namespace SoilMoistureSensor.Tests
{
   public class SoilMoistureStatusTests
   {
      [Theory]
      [InlineData(1)]
      [InlineData(0)]
      [InlineData(-1)]
      [InlineData(10.12)]
      [InlineData(10.1234)]
      [InlineData(1023)]
      public async void CorrectDataGetsSent(int value)
      {
         var IoTHubService = new IoTHubService("HostName=ECM3440.azure-devices.net;DeviceId=soil-moisture-sensor;SharedAccessKey=VGlo7rYmMZJVcVaJIehiOgF0QnUCmh3FHFxfpu9RukY=");

         var message = new SoilMoistureStatus { Value = value };
         await IoTHubService.SendAsync(message);
         var returnValue = message.Value;

         Assert.Equal(value, returnValue);
      }
   }
}