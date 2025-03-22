
using MongoDB.Driver;

namespace TournamentApp.Repositories;

public abstract class BaseRepository
{
    protected const string DatabaseName = "tournament";
    
    protected readonly IMongoClient mongoClient;

    public BaseRepository(IMongoClient mongoClient)
    {
        this.mongoClient = mongoClient;
    }

    protected IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return mongoClient.GetDatabase(DatabaseName)
            .GetCollection<T>(collectionName);
    }

    protected IQueryable<T> GetQueryable<T>(string collectionName)
    {
        return GetCollection<T>(collectionName)
            .AsQueryable();
    }
}