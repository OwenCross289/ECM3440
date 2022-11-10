using Dashboard;
using Dashboard.Models;

namespace Dashboard.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.True(true);
    }

    [Fact]
    public void CheckConstant()
    {
        Assert.Equal("ecm3440-telemetry-queue", Constants.QueueName);
    }

    [Fact]
    public void CheckSoilMoistureConstruction()
    {
        var sut = new SoilMoisture
        {
            Value = 5
        };
        
        Assert.Equal(5, sut.Value);
    }
}