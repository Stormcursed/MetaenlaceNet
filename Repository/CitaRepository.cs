using MetaenlaceNet.Entity;
using Microsoft.EntityFrameworkCore;

namespace MetaenlaceNet.Repository
{
    public class CitaRepository : EntityRepository<Cita, EntityContext>
    {
        public CitaRepository(EntityContext _context) : base(_context)
        {
            
        }
        public Cita GetCitaById(long id){
                Cita cita = _context.Set<Cita>()
                .Include(c => c.paciente)
                .Include(c => c.medico)
                .Single(c => c.CitaId == id);
                return cita;
        }

    }
}
