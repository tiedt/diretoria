using System;
using diretoriaAPI.Infrastructure.Interface;
using diretoriaAPI.Models;
using Microsoft.Extensions.Options;

namespace diretoriaAPI.Infrastructure.Repository;

public class DiretoriarRepository : DiretoriaSettingsRepository<DiretoriaModel>, IDiretoriaInterface
{
    public DiretoriarRepository(IOptions<DiretoriaDatabaseSettings> diretoriaDatabaseSettings) : base(diretoriaDatabaseSettings)
    {
    }
}