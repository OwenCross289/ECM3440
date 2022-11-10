using Dashboard;
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
}