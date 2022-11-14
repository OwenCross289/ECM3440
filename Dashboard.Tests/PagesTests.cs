using Bunit;
using Dashboard.Pages;
using Dashboard.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Dashboard.Tests;

public class PagesTests
{
    [Fact]
    public void GIVEN_ServiceIsNotConnected_WHEN_PageIsRendered_THEN_ServiceIsConnected()
    {
        // Arrange
        using var context = new TestContext();
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        
        var mockService = Substitute.For<IMessageQueueService>();
        context.Services.AddSingleton(mockService);
        
        // Act
        context.RenderComponent<SoilMoistureSensor>();

        // Assert
        mockService.Received(1).Connect();
    }
    
    [Fact]
    public void GIVEN_ServiceIsConnected_WHEN_UserClicksDisconnect_THEN_ServiceIsDisconnected()
    {
        // Arrange
        using var context = new TestContext();
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        
        var mockService = Substitute.For<IMessageQueueService>();
        context.Services.AddSingleton(mockService);
        
        var sut = context.RenderComponent<SoilMoistureSensor>();
        var disconnectButton = sut.Find("button");

        // Act
        disconnectButton.Click();

        // Assert
        mockService.Received(1).Disconnect();
    }
}