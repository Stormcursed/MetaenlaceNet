using AutoMapper;
using MetaenlaceNet.DTO;
using MetaenlaceNet.Entity;
using MetaenlaceNet.Mapper;
using MetaenlaceNet.Service;
using Microsoft.AspNetCore.Mvc;

namespace MetaenlaceNet.Controllers
{
    [ApiController]
    [Route("medicos")]
    public class MedicoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMedicoService _medicoService;

        public MedicoController(IMapper mapper, IMedicoService medicoService)
        {
            _mapper = mapper;
            _medicoService = medicoService;
        }

        [HttpGet("/medico/lista")]
        public List<MedicoOutDTO> GetMedicos()
        {
            List<MedicoOutDTO> list = new List<MedicoOutDTO>();
            foreach (var item in _medicoService.GetMedicos())
            {
                list.Add(_mapper.Map<MedicoOutDTO>(item));
            }
            return list;
        }
        [HttpGet("/medico/{clave}")]
        public MedicoOutDTO GetMedico(long clave)
        {
            Medico medico = _medicoService.GetMedicoById(clave);
            MedicoOutDTO medicoout = _mapper.Map<MedicoOutDTO>(medico);
            foreach (var item in medico.citas)
            {
                medicoout.citas.Add(_mapper.Map<CitaOutDTO>(item));
            }
            foreach (var item in medico.pacientes)
            {
                medicoout.pacientes.Add(_mapper.Map<PacienteOutDTO>(item));
            }
            return medicoout;
        }
            [HttpPost("/medico/añadir")]
        public MedicoOutDTO GuardarMedico([FromBody] MedicoInDTO medicoDTO)
        {
            Medico medico = _mapper.Map<Medico>(medicoDTO);
            _medicoService.SaveMedico(medico);
            return _mapper.Map<MedicoOutDTO>(medico);
        }
        [HttpDelete("/medico/delete/{clave}")]
        public MedicoOutDTO DeleteMedico(long clave)
        {
            MedicoOutDTO medico = _mapper.Map<MedicoOutDTO>(_medicoService.GetMedicoById(clave));
            _medicoService.deleteMedico(clave);
            return medico;
        }
    }
}
