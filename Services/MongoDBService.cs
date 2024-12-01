using MongoExample.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;

namespace MongoExample.Services;

public class MongoDbService
{
    private readonly IMongoCollection<Visitor> _visitorsCollection;

    public MongoDbService(IOptions<MongoDBSettings> mongoDbSettings,string connectionUri )
    {
        var client = new MongoClient(connectionUri);
        var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _visitorsCollection = database.GetCollection<Visitor>(mongoDbSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Visitor visitor)
    {
        await _visitorsCollection.InsertOneAsync(visitor);
      
    }

    public async Task<List<Visitor>> GetAsync()
    {
        return await _visitorsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<UpdateResult> UpdateVisitor(string id, Visitor visitor)
    {
        FilterDefinition<Visitor> filter = Builders<Visitor>.Filter.Eq("_id",  new ObjectId(id));
        UpdateDefinition<Visitor> update = Builders<Visitor>.Update
            .Set(v => v.Nome, visitor.Nome)
            .Set(v => v.Fone, visitor.Fone)
            .Set(v => v.Ativo, visitor.Ativo)
            .Set(v => v.NomeEmpresa, visitor.NomeEmpresa)
            .Set(v => v.UpdatedAt, DateTime.UtcNow);
        return await _visitorsCollection.UpdateOneAsync(filter, update);
    }

    public async Task<UpdateResult> DeleteVisitor(string id)
    {
        FilterDefinition<Visitor> filter = Builders<Visitor>.Filter.Eq("_id", new ObjectId(id));
        UpdateDefinition<Visitor> update = Builders<Visitor>.Update
            .Set("ativo",false);

        return await _visitorsCollection.UpdateOneAsync(filter, update);  
    }

}