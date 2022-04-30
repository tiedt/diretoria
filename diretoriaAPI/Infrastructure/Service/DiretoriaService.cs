using System;
using diretoriaAPI.Infrastructure.Interface;
using diretoriaAPI.Models;
using Microsoft.Extensions.Options;

namespace diretoriaAPI.Infrastructure.Service;

public class DiretoriaService : DiretoriaSettingsService<DiretoriaModel>, IDiretoriaService
{
    public DiretoriaService(IOptions<DiretoriaDatabaseSettings> diretoriaDatabaseSettings) : base(diretoriaDatabaseSettings)
    {
    }

    public Guid Cadastrar(string name, params string[] frases)
    {
        throw new NotImplementedException();
    }

    public void Remover(Guid guid)
    {
        throw new NotImplementedException();
    }
}