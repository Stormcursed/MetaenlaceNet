using MetaenlaceNet.Entity;

namespace MetaenlaceNet.Repository
{
    public class UsuarioRepository : EntityRepository<Usuario,EntityContext>
    {
        public UsuarioRepository(EntityContext _context) : base(_context)
        {
        }
    }
}
