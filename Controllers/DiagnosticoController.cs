using AutoMapper;
using MetaenlaceNet.DTO;
using MetaenlaceNet.Entity;
using MetaenlaceNet.Mapper;
using MetaenlaceNet.Service;
using Microsoft.AspNetCore.Mvc;

namespace MetaenlaceNet.Controllers
{
    [ApiController]
    [Route("diagnosticos")]
    public class DiagnosticoController : Controller
    {
        private readonly IDiagnosticoService _diagnosticoService;
        private readonly IMapper _mapper;

        public DiagnosticoController(IDiagnosticoService diagnosticoService, IMapper mapper)
        {
            _diagnosticoService = diagnosticoService;
            _mapper = mapper;
        }

        [HttpGet("/diagnostico/lista")]
        public List<DiagnosticoOutDTO> GetDiagnosticos()
        {
            List<DiagnosticoOutDTO> lista = new List<DiagnosticoOutDTO>();
            foreach (var diagnostico in _diagnosticoService.GetDiagnosticos())
            {
                lista.Add(_mapper.Map<DiagnosticoOutDTO>(diagnostico));
            }
            return lista;
        }

        [HttpGet("/diagnostico/{clave}")]
        public DiagnosticoOutDTO GetDiagnostico(long clave) 
        {
            return _mapper.Map<DiagnosticoOutDTO>(_diagnosticoService.GetDiagnosticoById(clave));
        }

        [HttpPost("/diagnostico/añadir")]
        public DiagnosticoOutDTO GuardarDiagnostico([FromBody]DiagnosticoInDTO diagnosticoDTO)
        {
            Diagnostico diagnostico = _mapper.Map<Diagnostico>(diagnosticoDTO);
            _diagnosticoService.SaveDiagnostico(diagnostico,diagnosticoDTO.cita);
            return _mapper.Map<DiagnosticoOutDTO>(diagnostico);
        }

        [HttpDelete("/diagnostico/delete/{clave}")]
        public DiagnosticoOutDTO DeleteDiagnsotico(long clave)
        {
            DiagnosticoOutDTO diagnostico = _mapper.Map<DiagnosticoOutDTO>(_diagnosticoService.GetDiagnosticoById(clave));
            _diagnosticoService.DeleteDiagnostico(clave);
            return diagnostico;
        }
    }
}
