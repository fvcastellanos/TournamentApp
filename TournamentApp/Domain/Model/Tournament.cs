using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TournamentApp.Domain.Model
{
    public class Tournament
    {
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("matches")]
        public List<Match> Matches { get; set; }
    }
}