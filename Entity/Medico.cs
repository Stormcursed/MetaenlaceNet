namespace MetaenlaceNet.Entity
{
    public class Medico : Usuario
    {
        public string numColegiado;

        public ICollection<Paciente> pacientes = new HashSet<Paciente>();
        public ICollection<Cita> citas = new HashSet<Cita>();

        public Medico(string nombre,
                      string apellidos,
                      string usuario,
                      string clave,
                      string numColegiado) :base(nombre, apellidos, usuario, clave)
        {   
            this.numColegiado = numColegiado;
 
        }

        public Medico()
        {

        }

        internal void AñadirPaciente(Paciente paciente)
        {
            this.pacientes.Add(paciente);
        }

        internal void AñadirCita(Cita cita)
        {
            this.AñadirCita(cita);
        }
    }
}
