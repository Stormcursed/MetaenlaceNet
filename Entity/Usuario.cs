namespace MetaenlaceNet.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string _Usuario { get; set; }
        public string Clave { get; set; }
        public Usuario(string nombre, string apellidos, string usuario, string clave) { 
            this.Nombre = nombre;
            this._Usuario = usuario;
            this.Apellidos = apellidos;
            this.Clave = clave;
        }

        public Usuario()
        {
        }
    }
}
