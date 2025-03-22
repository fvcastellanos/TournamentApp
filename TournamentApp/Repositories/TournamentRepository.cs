using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TournamentApp.Domain.Model;

namespace TournamentApp.Repositories;

public class TournamentRepository : BaseRepository
{
    private const string CollectionName = "tournaments";

    public TournamentRepository(IMongoClient mongoClient) : base(mongoClient)
    {
    }

    public async Task<List<Tournament>> GetTournamentsAsync()
    {
        return await GetQueryable<Tournament>(CollectionName)
            .ToListAsync();
    }

    public async Task<Tournament> GetTournamentAsync(string id)
    {
        return await GetQueryable<Tournament>(CollectionName)
            .FirstOrDefaultAsync(t => t.Id.Equals(id));
    }

    public async Task<Tournament> CreateTournamentAsync(Tournament tournament)
    {
        await GetCollection<Tournament>(CollectionName)
            .InsertOneAsync(tournament);

        return tournament;
    }

    public async Task<Tournament> UpdateTournamentAsync(string id, Tournament tournament)
    {
        await GetCollection<Tournament>(CollectionName)
            .ReplaceOneAsync(t => t.Id.Equals(id), tournament);

        return tournament;
    }

    public async Task DeleteTournamentAsync(string id)
    {
        await GetCollection<Tournament>(CollectionName)
            .DeleteOneAsync(t => t.Id.Equals(id));
    }
}