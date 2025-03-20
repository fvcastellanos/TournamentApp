
using Microsoft.AspNetCore.SignalR;

namespace TournamentApp.Hubs;

public class SimpleChatHub : Hub
{
    public const string HubUrl = "/chat-server";

    private readonly ILogger<SimpleChatHub> _logger;

    public SimpleChatHub(ILogger<SimpleChatHub> logger)
    {
        _logger = logger;
    }

    public async Task BroadcastMessage(string user, string message)
    {
        _logger.LogInformation($"Broadcasting message from {user}: {message}");
        await Clients.All.SendAsync("BroadcastMessage", user, message);
    }

    public override async Task OnConnectedAsync()
    {
        _logger.LogInformation($"{Context.ConnectionId} connected");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        _logger.LogInformation($"{Context.ConnectionId} disconnected");
        await base.OnDisconnectedAsync(exception);
    }
}
