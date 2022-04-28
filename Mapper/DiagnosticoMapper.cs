using AutoMapper;
using MetaenlaceNet.Entity;
using MetaenlaceNet.DTO;

namespace MetaenlaceNet.Mapper
{
    public class DiagnosticoMapper : Profile
    {
        public DiagnosticoMapper()
        {
            CreateMap<Diagnostico, DiagnosticoOutDTO>();
            CreateMap<DiagnosticoOutDTO, Diagnostico>();
            CreateMap<DiagnosticoInDTO, Diagnostico>();
            CreateMap<Diagnostico, DiagnosticoInDTO>();
        }
    }
}
