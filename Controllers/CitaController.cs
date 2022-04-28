using AutoMapper;
using MetaenlaceNet.DTO;
using MetaenlaceNet.Entity;
using MetaenlaceNet.Mapper;
using MetaenlaceNet.Service;
using Microsoft.AspNetCore.Mvc;

namespace MetaenlaceNet.Controllers
{
    [ApiController]
    [Route("citas")]
    public class CitaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICitaService _citaService;


        public CitaController(IMapper mapper, ICitaService citaService)
        {
            _mapper = mapper;
            _citaService = citaService;
        }



        [HttpGet("/cita/lista")]
        public List<CitaOutDTO> GetCitas()
        {
            List<CitaOutDTO> lista = new List<CitaOutDTO>();
            foreach (var cita in _citaService.GetCitas())
            {
                lista.Add(_mapper.Map<CitaOutDTO>(cita));
            }
            return lista;
        }
        [HttpGet("/cita/{clave}")]
        public CitaOutDTO GetCita(long clave)
        {
            Cita cita = _citaService.GetCitaById(clave);
            CitaOutDTO citaDTO = _mapper.Map<CitaOutDTO>(cita);
            citaDTO.paciente = _mapper.Map<PacienteOutDTO>(cita.paciente);
            citaDTO.medico = _mapper.Map<MedicoOutDTO>(cita.medico);
            if (cita.diagnostico != null) { citaDTO.diagnostico = _mapper.Map<DiagnosticoOutDTO>(cita.diagnostico);}
            return citaDTO;
        }
        [HttpPost("/cita/añadir")]
        public CitaOutDTO GuardarCita([FromBody]CitaInDTO citaDTO)
        {
            Cita cita = _citaService.SaveCita(citaDTO);
            return _mapper.Map<CitaOutDTO>(cita);
            
        }
        [HttpDelete("/cita/delete/{clave}")]
        public CitaOutDTO DeleteCita(long clave)
        {
            CitaOutDTO cita = _mapper.Map<CitaOutDTO>(_citaService.GetCitaById(clave));
            _citaService.DeleteCita(clave);
            return cita;
        }
    }
}
