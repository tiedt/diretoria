using AutoMapper;
using diretoriaAPI.DTO;
using diretoriaAPI.Models;

namespace diretoriaAPI.Infrastructure
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<DiretoriaModel, DiretoriaDTO>().ReverseMap();
            CreateMap<FraseModel, FraseDTO>().ReverseMap(); 
        }
    }
}
