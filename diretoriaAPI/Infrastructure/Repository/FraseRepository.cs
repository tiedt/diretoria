using System;
using diretoriaAPI.Infrastructure.Interface;
using diretoriaAPI.Models;
using Microsoft.Extensions.Options;

namespace diretoriaAPI.Infrastructure.Repository;

public class FraseRepository : DiretoriaSettingsRepository<FraseModel>, IFraseInterface
{
    public FraseRepository(IOptions<DiretoriaDatabaseSettings> diretoriaDatabaseSettings) : base(diretoriaDatabaseSettings)
    {
    }
}