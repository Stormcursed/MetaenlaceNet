using MetaenlaceNet.Entity;

namespace MetaenlaceNet.Repository
{
    public class DiagnosticoRepository : EntityRepository<Diagnostico, EntityContext>
    {
        public DiagnosticoRepository(EntityContext _context) : base(_context)
        {
        }
    }
}
