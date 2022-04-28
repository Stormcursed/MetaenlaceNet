using MetaenlaceNet.Entity;
using MetaenlaceNet.Repository;

namespace MetaenlaceNet.Service
{
    public class MedicoService : IMedicoService
    { 
        public MedicoRepository MedicoRepository { get; set; }
        public CitaRepository CitaRepository { get; set; }
        public PacienteRepository PacienteRepository { get; set; }
        public MedicoService(MedicoRepository medicoRepository, PacienteRepository pacienteRepository, CitaRepository citaRepository)
        {
            this.MedicoRepository = medicoRepository;
            this.CitaRepository = citaRepository;
            this.PacienteRepository = pacienteRepository;
        }
        public List<Medico> GetMedicos()
        {
            return (List<Medico>)MedicoRepository.GetAll();
        }
        public Medico? AñadirPaciente(Medico medico, long clavePaciente)
        {
            Paciente paciente = PacienteRepository.GetEntityById(clavePaciente).Result;
            if (paciente == null)
            {
                return null;
            }
            paciente.AñadirMedico(medico);
            medico.AñadirPaciente(paciente);
            PacienteRepository.UpdateEntity(paciente);
            return MedicoRepository.UpdateEntity(medico);
        } 
        public Medico? AñadirCitaMedico(Medico medico, long claveCita)
        {   
            Cita cita = CitaRepository.GetEntityById(claveCita).Result;
            if(cita == null) { return null; }
            medico.AñadirCita(cita);
            return MedicoRepository.UpdateEntity(medico);
        }
        public Medico SaveMedico(Medico medico)
        {
            return MedicoRepository.InsertEntity(medico);
        }
        public Medico? GetMedicoById(long id)
        {
            return MedicoRepository.GetMedicoById(id);
        }
        public void deleteMedico(long clave)
        {
            MedicoRepository.DeleteEntity(clave);
        }
    }
}
