
namespace TournamentApp.Domain.Web
{
    public class ErrorMessage
    {
        public bool ShowMessage { get; set; }
        public string Message { get; set; }

        public ErrorMessage()
        {
            ShowMessage = false;
            Message = string.Empty;
        }

        public ErrorMessage(string message)
        {
            ShowMessage = true;
            Message = message;
        }

        public void HideMessage()
        {
            ShowMessage = false;
        }

        public void DisplayMessage(string message)
        {
            ShowMessage = true;
            Message = message;

        }
    }
}