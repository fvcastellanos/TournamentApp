
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TournamentApp.Domain.Model;

public class Player
{
    public ObjectId Id { get; set; }

    public string Name { get; set; }
    public int Score { get; set; }

    [BsonElement("isWinner")]
    public bool IsWinner { get; set; }
    public int Flags { get; set; }
}

