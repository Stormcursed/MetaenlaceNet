namespace MetaenlaceNet.Entity
{
    public class Paciente : Usuario
    {
        private string NSS { get; set; }
        private string numTarjeta { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

        public ICollection<Medico> medicos = new HashSet<Medico>();
        public ICollection<Cita> citas = new HashSet<Cita>();

        public Paciente(
            string nombre,
            string apellidos,
            string usuario,
            string clave,
            string NSS,
            string numTarjeta,
            string telefono,
            string direccion) : base(nombre, apellidos, usuario, clave)
        {
            this.NSS = NSS;
            this.numTarjeta = numTarjeta;
            this.telefono = telefono;
            this.direccion = direccion;
        }

        public Paciente()
        {
        }

        internal void AñadirMedico(Medico medico)
        {
            this.medicos.Add(medico);
        }

        internal void AñadirCita(Cita cita)
        {
            this.citas.Add(cita);
        }
    }
}
