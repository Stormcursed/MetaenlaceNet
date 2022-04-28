using MetaenlaceNet.Entity;
using MetaenlaceNet.Repository;

namespace MetaenlaceNet.Service
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioRepository UsuarioRepository { get; set; }
        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            this.UsuarioRepository = usuarioRepository;
        }
    }
}
