using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TournamentApp.Services;

namespace TournamentApp.Components.Pages
{
    public class ChatPage : PageBase
    {
        protected bool IsRegistered { get; set; }
        protected string? Nickname { get; set; }

        protected string? Message { get; set; }

        protected IEnumerable<string> Messages;
        protected IEnumerable<string> Users;

        [Inject]
        protected ChatService ChatService { get; set; }

        protected override void OnInitialized()
        {
            Nickname = "Anonymous";
            Message = string.Empty;
            IsRegistered = false;
            Messages = [];
            Users = [];
        }

        protected void Register()
        {
            ChatService.RegisterUser(Nickname);
            Messages = ChatService.GetMessages();
            Users = ChatService.GetUsers();

            IsRegistered = true;
        }

        protected void SendMessage()
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                return;
            }

            ChatService.SendMessage($"{Nickname}: {Message}");
            Message = string.Empty;
        }

        protected void Unregister()
        {
            ChatService.UnregisterUser(Nickname);
            Messages = [];
            Users = [];
            IsRegistered = false;
        }

        protected void HandleKeyPress(KeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                SendMessage();
            }
        }

        protected void GetMessages()
        {
            ChatService.GetMessages();
        }
        
    }
}
