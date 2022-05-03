using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using diretoriaAPI.Infrastructure.Interface;
using diretoriaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace diretoriaAPI.Infrastructure.Repository;

public class DiretoriaSettingsRepository<T> : IDiretoriaSettingsInterface<T> where T : BaseModel
{
    private readonly IMongoCollection<T> Collection;
    protected DiretoriaSettingsRepository(
        IOptions<DiretoriaDatabaseSettings> diretoriaDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            diretoriaDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            diretoriaDatabaseSettings.Value.DatabaseName);

        Collection = mongoDatabase.GetCollection<T>(
            diretoriaDatabaseSettings.Value.DiretoriaCollectionName);
    }

    public async Task<List<T>> GetAsync() =>
        await Collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(string id) =>
        await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(T t) =>
        await Collection.InsertOneAsync(t);

    public async Task UpdateAsync(string id, T t) =>
        await Collection.ReplaceOneAsync(x => x.Id == id, t);

    public async Task RemoveAsync(string id) =>
        await Collection.DeleteOneAsync(x => x.Id == id);
}