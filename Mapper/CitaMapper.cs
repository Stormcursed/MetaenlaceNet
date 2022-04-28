using AutoMapper;
using MetaenlaceNet.Entity;
using MetaenlaceNet.DTO;

namespace MetaenlaceNet.Mapper
{
    public class CitaMapper : Profile
    {
        public CitaMapper() 
        {
            CreateMap<Cita, CitaOutDTO>().ForMember(c => c.diagnostico, opt => opt.AllowNull())
                .ForMember(c => c.paciente, opt => opt.Ignore()).ForMember(c =>  c.medico, opt => opt.Ignore());
            CreateMap<CitaInDTO, Cita>();
            CreateMap<Cita, CitaInDTO>();
        }
    }
}
