
namespace TournamentApp.Domain.Web.Chat
{
    public class Message
    {
        public string Username { get; set; }
        public string Content { get; set; }
        public bool Mine { get; set; }

        public Message(string username, string content, bool mine)
        {
            Username = username;
            Content = content;
            Mine = mine;
        }

        public bool IsNotice => Content.StartsWith("Notice:");

        public string CSS => Mine ? "sent" : "received";
    }
}
