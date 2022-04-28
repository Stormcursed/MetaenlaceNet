using AutoMapper;
using MetaenlaceNet.Entity;
using MetaenlaceNet.DTO;

namespace MetaenlaceNet.Mapper
{
    public class MedicoMapper : Profile
    {
        public MedicoMapper()
        {
            CreateMap<Medico, MedicoOutDTO>().ForMember(p => p.citas, opt => opt.Ignore()).ForMember(p => p.pacientes, opt => opt.Ignore());
            CreateMap<MedicoOutDTO, Medico>();
            CreateMap<MedicoInDTO, Medico>();
            CreateMap<Medico, MedicoInDTO>();
        }
    }
}
