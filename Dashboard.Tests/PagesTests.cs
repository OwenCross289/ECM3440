using Bunit;
using Dashboard.Pages;
using Dashboard.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Dashboard.Tests;

public class PagesTests
{
    [Fact]
    public void ConnectOnStartup()
    {
        // Arrange
        using var context = new TestContext();
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        
        var mockService = new Mock<IMessageQueueService>();
        mockService.Setup(x => x.Connect());
        context.Services.AddSingleton(mockService.Object);
        
        // Act
        context.RenderComponent<SoilMoistureSensor>();

        // Assert
        mockService.VerifyAll(); 
    }
    
    [Fact]
    public void GIVEN_ServiceIsConnected_WHEN_UserClicksDisconnect_THEN_ServiceIsDisconnected()
    {
        // Arrange
        using var context = new TestContext();
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        
        var mockService = new Mock<IMessageQueueService>();
        mockService.Setup(x => x.Disconnect());
        context.Services.AddSingleton(mockService.Object);
        
        var sut = context.RenderComponent<SoilMoistureSensor>();
        var disconnectButton = sut.Find("button");

        // Act
        disconnectButton.Click();

        // Assert
        mockService.VerifyAll();
    }
}