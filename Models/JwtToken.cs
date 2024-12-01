using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;

namespace MongoExample.Models;

public class JwtToken
{
    public JwtToken(string imei, string uuidFirebase, string idMobile)
    {
        Imei = imei;
        
        UuidFirebase = uuidFirebase;
        IdMobile = idMobile;
    }

    [BsonElement("imei")]
    public string Imei{get;set;}

    [BsonElement("uidFirebase")]
    public string UuidFirebase {get;set;}
    [BsonElement("idMobile")] 
    public string IdMobile{get;set;}
    
}