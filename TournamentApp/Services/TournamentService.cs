using MongoDB.Bson;
using TournamentApp.Domain.Model;
using TournamentApp.Repositories;

namespace TournamentApp.Services
{

    public class TournamentService
    {
        private readonly ILogger<TournamentService> _logger;
        private readonly TournamentRepository _tournamentRepository;

        public TournamentService(ILogger<TournamentService> logger, 
                                 TournamentRepository tournamentRepository)
        {
            _logger = logger;
            _tournamentRepository = tournamentRepository;
        }

        public async Task<IEnumerable<Tournament>> GetTournaments()
        {

            return await _tournamentRepository.GetTournamentsAsync();

            // var tournaments = new List<Tournament>
            // {
            //     new Tournament
            //     {
            //         Id = ObjectId.GenerateNewId(),
            //         Name = "Tournament 1",
            //         Description = "Description 1",
            //         Location = "Location 1",
            //         Matches = new List<Match>
            //         {
            //             new Match
            //             {
            //                 Id = ObjectId.GenerateNewId(),
            //                 // Team1 = "Team 1",
            //                 // Team2 = "Team 2",
            //                 // Score1 = 1,
            //                 // Score2 = 2
            //             }
            //         }
            //     },
            //     new Tournament
            //     {
            //         Id = ObjectId.GenerateNewId(),
            //         Name = "Tournament 2",
            //         Description = "Description 2",
            //         Location = "Location 2",
            //         Matches = new List<Match>
            //         {
            //             new Match
            //             {
            //                 Id = ObjectId.GenerateNewId(),
            //                 // Team1 = "Team 3",
            //                 // Team2 = "Team 4",
            //                 // Score1 = 3,
            //                 // Score2 = 4
            //             }
            //         }
            //     }
            // };

            // return await Task.FromResult(tournaments);
        }
    }
}