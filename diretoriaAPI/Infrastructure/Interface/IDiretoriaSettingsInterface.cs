using diretoriaAPI.Models;

namespace diretoriaAPI.Infrastructure.Interface;

public interface IDiretoriaSettingsInterface<T> where T : BaseModel
{
    Task<List<T>> GetAsync();
    Task<T> GetAsync(Guid id);
    Task CreateAsync(T t);
    Task UpdateAsync(Guid id, T t);
    Task RemoveAsync(Guid id);
}