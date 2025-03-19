
namespace TournamentApp.Services;

public class ChatService
{
    private readonly List<string> _messages;
    private readonly List<string> _users;

    public ChatService()
    {
        _messages = [];
        _users = [];
    }

    public void RegisterUser(string nickname)
    {
        _users.Add(nickname);
    }

    public void SendMessage(string message)
    {
        _messages.Add(message);
    }

    public List<string> GetMessages()
    {
        return _messages;
    }

    public List<string> GetUsers()
    {
        return _users;
    }

    public void UnregisterUser(string nickname)
    {
        _users.Remove(nickname);
    }
    

}