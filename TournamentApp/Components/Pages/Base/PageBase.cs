using Microsoft.AspNetCore.Components;

namespace TournamentApp.Components.Pages
{
    public abstract class PageBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected void NavigateTo(string uri)
        {
            NavigationManager.NavigateTo(uri);
        }
    }
}
