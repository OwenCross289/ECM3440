using System.Diagnostics.CodeAnalysis;
using Dashboard.Services.Implementations;
using Dashboard.Services.Interfaces;

namespace Dashboard;

[ExcludeFromCodeCoverage]
public static class WebApplicationBuilderExtensions
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddTransient<IMessageQueueService, MessageQueueService>();
    }
}