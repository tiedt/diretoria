using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace diretoriaAPI.Models;

public class BaseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}