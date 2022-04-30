namespace diretoriaAPI.Models;

public class DiretoriaModel : BaseModel
{
    public string Name { get; set; } = null;
    public List<FraseModel> Frases { get; set; } = null;
}