using MetaenlaceNet.Entity;
using Microsoft.EntityFrameworkCore;

namespace MetaenlaceNet.Repository
{
    public class PacienteRepository : EntityRepository<Paciente, EntityContext>
    {
        public PacienteRepository(EntityContext _context) : base(_context)
        {
        }
        public Paciente GetPacienteById(long id)
        {
            Paciente paciente = _context.Set<Paciente>()
            .Include(c => c.citas)
            .Include(c => c.medicos)
            .Single(c => c.UsuarioId == id);
            return paciente;
        }
    }
}
