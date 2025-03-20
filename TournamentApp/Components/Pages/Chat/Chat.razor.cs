using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TournamentApp.Domain.Web.Chat;
using TournamentApp.Hubs;
using TournamentApp.Services;

using Microsoft.AspNetCore.SignalR.Client;

namespace TournamentApp.Components.Pages
{
    public class ChatPage : PageBase
    {
        private const string MethodName = "BroadcastMessage";
        protected bool IsRegistered { get; set; }

        protected bool ShowMessage { get; set; }
        protected string ErrorMessage { get; set; }

        protected string? Nickname { get; set; }

        protected string? Message { get; set; }

        protected List<Message> Messages { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        private HubConnection _hubConnection;

        protected override void OnInitialized()
        {
            Nickname = "Anonymous";
            Message = string.Empty;
            IsRegistered = false;
            Messages = [];
            ShowMessage = false;
            // Users = [];
        }

        protected async Task Register()
        {
            if (string.IsNullOrWhiteSpace(Nickname))
            {
                return;
            }

            try 
            {
                await Task.Delay(10);
                Messages.Clear();

                var baseUrl = NavigationManager.BaseUri;
                var hubUrl = baseUrl.TrimEnd('/') + SimpleChatHub.HubUrl;

                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(hubUrl)
                    .Build();

                _hubConnection.On<string, string>(MethodName, BroadcastMessage);

                await _hubConnection.StartAsync();

                await SendAsync($"{Nickname} has joined the chat.");
                IsRegistered = true;
            }
            catch (Exception ex)
            {
                IsRegistered = false;

                ShowMessage = true;
                ErrorMessage = "An error occurred while trying to connect to the chat server. Please try again later.";
            }
        }

        protected async Task SendAsync(string message)
        {
            if (IsRegistered && !string.IsNullOrWhiteSpace(message))
            {
                await _hubConnection.SendAsync(MethodName, Nickname, message);

                Message = string.Empty;
            }
        }

        protected async Task DisconnectAsync()
        {
            if (IsRegistered)
            {
                await SendAsync($"{Nickname} has left the chat.");

                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();

                _hubConnection = null;
                IsRegistered = false;
            }
        }

        private void BroadcastMessage(string nickname, string message)
        {
            var isMine = nickname.Equals(Nickname, StringComparison.OrdinalIgnoreCase);
            Messages.Add(new Message(nickname, message, isMine));

            InvokeAsync(StateHasChanged);
        }        
    }
}
