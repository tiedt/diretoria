using System;

namespace diretoriaAPI.Infrastructure.Interface;

public interface IFraseService
{
    Guid Cadastrar(string name, Guid diretoriaGuid);
    void Remover(Guid guid);
}