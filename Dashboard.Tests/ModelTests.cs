using System.Diagnostics.Metrics;
using Dashboard;
using Dashboard.Models;

namespace Dashboard.Tests;

public class ModelTests
{
    [Fact]
    public void SoilMoistureConstruction()
    {
        var expectedTime = new DateTime(2015, 5, 5);
        var sut = new SoilMoisture
        {
            Value = 5,
            Time = expectedTime
        };
        
        Assert.Equal(5, sut.Value);
        Assert.Equal(expectedTime, sut.Time);
    }
}