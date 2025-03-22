using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TournamentApp.Domain.Model;

public class Match
{
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("redPlayer")]
    public Player RedPlayer { get; set; }

    [BsonElement("bluePlayer")]
    public Player BluePlayer { get; set; }

    public Player Winner { get; set; }
    public Player Loser { get; set; }

    [BsonElement("judges")]
    public IEnumerable<Judge> Judges { get; set; }

    [BsonElement("round")]
    public string Round { get; set; }

    [BsonElement("time")]
    public string Time { get; set; }

    [BsonElement("date")]
    public string Date { get; set; }

    [BsonElement("location")]
    public string Location { get; set; }

    [BsonElement("type")]
    public string Type { get; set; }
}
