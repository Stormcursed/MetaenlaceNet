using MetaenlaceNet.Entity;
using Microsoft.EntityFrameworkCore;

namespace MetaenlaceNet.Repository
{
    public class MedicoRepository : EntityRepository<Medico, EntityContext>
    {
        public MedicoRepository(EntityContext _context) : base(_context)
        {
        }
        public Medico GetMedicoById(long id)
        {
            if (_context.Set<Medico>().Single(c => c.UsuarioId == id) == null) { }
            Medico medico = _context.Set<Medico>()
            .Include(c => c.citas)
            .Include(c => c.pacientes)
            .Single(c => c.UsuarioId == id)
            ;
            return medico;
        }
    }
}
