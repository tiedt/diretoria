using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using diretoriaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace diretoriaAPI.Infrastructure.Service;

public abstract class DiretoriaSettingsService<T> where T : BaseModel
{
    private readonly IMongoCollection<T> _collection;

    protected DiretoriaSettingsService(
        IOptions<DiretoriaDatabaseSettings> diretoriaDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            diretoriaDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            diretoriaDatabaseSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<T>(
            diretoriaDatabaseSettings.Value.DiretoriaCollectionName);
    }

    public async Task<List<T>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(Guid id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(T t) =>
        await _collection.InsertOneAsync(t);

    public async Task UpdateAsync(Guid id, T t) =>
        await _collection.ReplaceOneAsync(x => x.Id == id, t);

    public async Task RemoveAsync(Guid id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}