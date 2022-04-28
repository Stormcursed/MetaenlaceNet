using MetaenlaceNet.Entity;
using MetaenlaceNet.Repository;

namespace MetaenlaceNet.Service
{
    public class DiagnosticoService : IDiagnosticoService
    {

        public DiagnosticoRepository DiagnosticoRepository;
        public CitaRepository CitaRepository;
        public DiagnosticoService(DiagnosticoRepository diagnosticoRepository, CitaRepository citaRepository)
        {
            DiagnosticoRepository = diagnosticoRepository;
            CitaRepository = citaRepository;
        }
        public Diagnostico? GetDiagnosticoById(long Id)
        {
            return DiagnosticoRepository.GetEntityById(Id).Result;
        }
        public Diagnostico? SaveDiagnostico(Diagnostico diagnostico, long citaId)
        {
            Cita cita = CitaRepository.GetCitaById(citaId);
            if (cita == null) { return null;}
            diagnostico.cita = cita;
            return DiagnosticoRepository.InsertEntity(diagnostico);
        }
        public void DeleteDiagnostico(long diagnosticoId)
        {
            DiagnosticoRepository.DeleteEntity(diagnosticoId);
        }
        public List<Diagnostico> GetDiagnosticos()
        {
            return (List<Diagnostico>)DiagnosticoRepository.GetAll();
        }
    }
}
