using System.Collections.Generic;

namespace diretoriaAPI.Models;

public class DiretoriaModel : BaseModel
{
    public string Name { get; set; }
    public List<FraseModel> Frases { get; set; }
}