using MetaenlaceNet.Entity;
using MetaenlaceNet.Repository;
using MetaenlaceNet.DTO;
using MetaenlaceNet.Mapper;
using AutoMapper;

namespace MetaenlaceNet.Service
{
    public class CitaService : ICitaService
    {
        public CitaRepository CitaRepository { get; set; }
        public PacienteRepository PacienteRepository { get; set; }
        public IMedicoService MedicoService { get; set; }
        public MedicoRepository MedicoRepository { get; set; }
        private readonly IMapper _mapper;

        public CitaService(CitaRepository citaRepository, MedicoRepository medicoRepository, PacienteRepository pacienteRepository, IMapper mapper)
        {
            this.CitaRepository = citaRepository;
            this.MedicoRepository = medicoRepository;
            this.PacienteRepository = pacienteRepository;
            _mapper = mapper;
        }
        public Cita? SaveCita(CitaInDTO citaDTO)
        {
            Cita cita = new();
            cita.fechaHora = citaDTO.fechaHora;
            cita.motivocita = citaDTO.motivocita;

            Medico medico = MedicoRepository.GetEntityById(citaDTO.medico).Result;
            Paciente paciente = PacienteRepository.GetEntityById(citaDTO.paciente).Result;
            if ((paciente is null) || (medico is null))
            {
                throw new Exception("paciente y/o medico nulo");
            }
            medico.AñadirPaciente(paciente);

            cita.medico = medico;
            cita.paciente = paciente;
            PacienteRepository.UpdateEntity(paciente);

            return CitaRepository.InsertEntity(cita);
        }
        public void DeleteCita(long Id)
        {
            CitaRepository.DeleteEntity(Id);
        }
        public Cita? GetCitaById(long Id)
        {
            Cita cita = CitaRepository.GetCitaById(Id);
            return cita;
        }
        public List<CitaOutDTO> GetCitas()
        {
            return (List<CitaOutDTO>)CitaRepository.GetAll();
        }


    }
}
