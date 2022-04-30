namespace diretoriaAPI.Models;
public class DiretoriaDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string DiretoriaCollectionName { get; set; } = null!;
}