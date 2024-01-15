using MongoDB.Bson.Serialization.Attributes;

namespace NewApi.Models;
[BsonIgnoreExtraElements]
 public class Team{
   [BsonId]
   [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set;}
    [BsonElement("name")]
    public string? Name { get; set;}
    [BsonElement("country")]
    public string? Country { get; set;}
    [BsonElement("teamprinciple")]
    public string? TeamPrinciple { get; set;}
 }