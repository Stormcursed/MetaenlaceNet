using MetaenlaceNet.Entity;

namespace MetaenlaceNet.Service
{
    public interface IMedicoService
    {
        public List<Medico> GetMedicos();
        public Medico? AñadirPaciente(Medico medico, long clavePaciente);
        public Medico? AñadirCitaMedico(Medico medico, long claveCita);
        public Medico SaveMedico(Medico medico);
        public Medico? GetMedicoById(long id);
        public void deleteMedico(long clave);
    }
}
