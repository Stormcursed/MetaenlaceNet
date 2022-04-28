using MetaenlaceNet.Entity;

namespace MetaenlaceNet.Service
{
    public interface IDiagnosticoService
    {
        public Diagnostico? GetDiagnosticoById(long Id);
        public Diagnostico? SaveDiagnostico(Diagnostico diagnostico, long citaId);
        public void DeleteDiagnostico(long diagnosticoId);
        public List<Diagnostico> GetDiagnosticos();
    }
}
