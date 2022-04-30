using System;

namespace diretoriaAPI.Infrastructure.Interface;

public interface IDiretoriaService
{
    Guid Cadastrar(string name, params string[] frases);
    void Remover(Guid guid);
}