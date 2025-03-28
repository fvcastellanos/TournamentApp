using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TournamentApp.Domain.Model
{
    public class Judge
    {
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}