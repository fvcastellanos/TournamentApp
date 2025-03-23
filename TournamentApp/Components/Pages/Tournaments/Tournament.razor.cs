
using Microsoft.AspNetCore.Components;
using TournamentApp.Domain.Model;
using TournamentApp.Services;

namespace TournamentApp.Components.Pages;

public class TournamentPage: CrudBase
{
    protected IEnumerable<Tournament> Tournaments { get; set; }

    [Inject]
    protected TournamentService TournamentService { get; set; }

    protected override void Add()
    {
        throw new NotImplementedException();
    }

    protected override async Task OnInitializedAsync()
    {
        // Tournaments = await TournamentService.GetTournaments();

        // Tournaments = [];
        HideErrorMessage();        
        Tournaments = await TournamentService.GetTournaments();

    }

    protected override void Update()
    {
        throw new NotImplementedException();
    }


}