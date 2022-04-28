using MetaenlaceNet.Entity;
using MetaenlaceNet.Repository;
using MetaenlaceNet.Mapper;
using AutoMapper;
using MetaenlaceNet.DTO;

namespace MetaenlaceNet.Service
{
    public class PacienteService : IPacienteService
    {
        public PacienteRepository PacienteRepository { get; set; }
        public MedicoRepository MedicoRepository { get; set; }
        public CitaRepository CitaRepository { get; set; }

        private readonly IMapper mapper;
        public PacienteService(PacienteRepository pacienteRepository, MedicoRepository medicoRepository, CitaRepository citaRepository, IMapper mapper)
        {
            this.PacienteRepository = pacienteRepository;
            this.MedicoRepository = medicoRepository;
            this.CitaRepository = citaRepository;
            this.mapper = mapper;
        }
        public List<Paciente> GetPacientes() 
        {
            return (List<Paciente>)PacienteRepository.GetAll();
        }
        public Paciente SavePaciente(Paciente paciente) 
        {
            return PacienteRepository.InsertEntity(paciente);
        }
        public PacienteOutDTO? GetPacienteById(long id)
        {
            Paciente paciente = new Paciente();
            paciente = PacienteRepository.GetPacienteById(id);
            PacienteOutDTO pacienteout = mapper.Map<PacienteOutDTO>(paciente);
            foreach (var item in paciente.citas)
            {
                pacienteout.citas.Add(mapper.Map<CitaOutDTO>(item));
            }
            foreach (var item in paciente.medicos)
            {
                pacienteout.medicos.Add(mapper.Map<MedicoOutDTO>(item));
            }
            return pacienteout;
        }
        public Paciente? AñadirMedico(Paciente paciente, long claveMedico)
        {
            Medico medico = MedicoRepository.GetEntityById(claveMedico).Result;
            if (medico == null) 
            {
                return null;
            }
            paciente.AñadirMedico(medico);
            medico.AñadirPaciente(paciente);
            MedicoRepository.UpdateEntity(medico);
            return PacienteRepository.UpdateEntity(paciente);
        }
        public Paciente? AñadirCitaPaciente(Paciente paciente, long claveCita)
        {
            Cita cita = CitaRepository.GetEntityById(claveCita).Result;
            if (cita == null)
            {
                return null;
            }
            paciente.AñadirCita(cita);
            
            return PacienteRepository.UpdateEntity(paciente);
        }
        public void DeletePaciente(long clave)
        {
            PacienteRepository.DeleteEntity(clave);
        }

    }
}
