using AutoMapper;
using MetaenlaceNet.DTO;
using MetaenlaceNet.Entity;
using MetaenlaceNet.Mapper;
using MetaenlaceNet.Service;
using Microsoft.AspNetCore.Mvc;

namespace MetaenlaceNet.Controllers   
{
    [ApiController]
    [Route("pacientes")]
    public class PacienteController : Controller
    {
        private readonly IPacienteService IpacienteService;
        private readonly IMapper mapper;

        public PacienteController(IPacienteService pacienteService, IMapper mapper)
        {
            IpacienteService = pacienteService;
            this.mapper = mapper;

        }

        [HttpGet("/paciente/lista")]
        public List<PacienteOutDTO> GetPacientes()
        {
            List<PacienteOutDTO> pacientes = new();

            foreach(var item in IpacienteService.GetPacientes())
            {
                pacientes.Add(mapper.Map<PacienteOutDTO>(item));
            }
            return pacientes;
        }
        [HttpGet("/paciente/{clave}")]
        public PacienteOutDTO GetPaciente(long clave)
        {
            PacienteOutDTO pacienteout = IpacienteService.GetPacienteById(clave);
            return pacienteout;
        }
        [HttpPost("/paciente/añadir")]
        public PacienteOutDTO GuardarUsuario([FromBody]PacienteInDTO pacienteDTO)
        {
            Paciente paciente = mapper.Map<Paciente>(pacienteDTO);
            IpacienteService.SavePaciente(paciente);
            return mapper.Map<PacienteOutDTO>(paciente);
        }
        [HttpDelete("/paciente/delete/{clave}")]
        public PacienteOutDTO DeletePaciente(long clave)
        {
            PacienteOutDTO paciente = mapper.Map<PacienteOutDTO>(IpacienteService.GetPacienteById(clave));
            IpacienteService.DeletePaciente(clave);
            return paciente;
        }
    }
}
