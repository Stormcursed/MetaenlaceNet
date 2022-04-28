using MetaenlaceNet.Entity;
using MetaenlaceNet.DTO;

namespace MetaenlaceNet.Service
{
    public interface IPacienteService
    {
        public List<Paciente> GetPacientes();

        public Paciente SavePaciente(Paciente paciente);

        public PacienteOutDTO? GetPacienteById(long id);

        public Paciente? AñadirMedico(Paciente paciente, long claveMedico);

        public Paciente? AñadirCitaPaciente(Paciente paciente, long claveCita);

        public void DeletePaciente(long clave);


    }
}
