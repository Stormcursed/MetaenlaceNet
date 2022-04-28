using AutoMapper;
using MetaenlaceNet.Entity;
using MetaenlaceNet.DTO;

namespace MetaenlaceNet.Mapper
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<Paciente, PacienteOutDTO>().ForMember(p => p.citas, opt => opt.Ignore()).ForMember(p => p.medicos, opt => opt.Ignore());
            CreateMap<PacienteOutDTO, Paciente>();
            CreateMap<PacienteInDTO, Paciente>();
            CreateMap<Paciente, PacienteInDTO>();
        }
    }
}
