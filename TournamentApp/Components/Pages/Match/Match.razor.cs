
using TournamentApp.Domain.Web;

namespace TournamentApp.Components.Pages
{
    public class MatchPage : PageBase
    {
        protected bool IsJudgeRegistered { get; set; }

        protected ErrorMessage ErrorMessage { get; set; }

        protected void OnInitializedAsync()
        {
            IsJudgeRegistered = false;
            ErrorMessage = new ErrorMessage();
        }

        

    }
}