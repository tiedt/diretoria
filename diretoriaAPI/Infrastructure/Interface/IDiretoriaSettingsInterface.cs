using diretoriaAPI.Models;

namespace diretoriaAPI.Infrastructure.Interface;

public interface IDiretoriaSettingsInterface<T> where T : BaseModel
{
    Task<List<T>> GetAsync();
    Task<T> GetAsync(string id);
    Task CreateAsync(T t);
    Task UpdateAsync(string id, T t);
    Task RemoveAsync(string id);
}