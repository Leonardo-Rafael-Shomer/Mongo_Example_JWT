using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;

namespace MongoExample.Models;

public class Perfil
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }
    [BsonElement("updatedAt"),]
    public DateTime UpdatedAt { get; set; }
    [BsonElement("ativo")]
    public bool Ativo { get; set; }
    [BsonElement("userId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? UserId { get; set; }
    [BsonElement("filename")]
    public string Filename { get; set; }
    [BsonElement("path")]
    public string Path { get; set; }
    [BsonElement("mimeType")]
    public string MimeType { get; set; }
}