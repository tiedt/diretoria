using System;
using diretoriaAPI.Infrastructure.Interface;
using diretoriaAPI.Models;
using Microsoft.Extensions.Options;

namespace diretoriaAPI.Infrastructure.Service;

public class FraseService : DiretoriaSettingsService<FraseModel>, IFraseService
{
    public FraseService(IOptions<DiretoriaDatabaseSettings> diretoriaDatabaseSettings) : base(diretoriaDatabaseSettings)
    {
    }

    public Guid Cadastrar(string name, Guid diretoriaGuid)
    {
        throw new NotImplementedException();
    }

    public void Remover(Guid guid)
    {
        throw new NotImplementedException();
    }
}