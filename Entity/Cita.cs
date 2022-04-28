namespace MetaenlaceNet.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cita
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CitaId { get; set; }
        public DateTime fechaHora { get; set; }
        public string motivocita { get; set; }

        public Diagnostico diagnostico { get; set; }
        public Paciente paciente { get; set; }
        public Medico medico { get; set; }

        public Cita(DateTime fechaHora, 
                string motivocita, 
                Diagnostico diagnostico, 
                Paciente paciente, 
                Medico medico)
        {
            this.fechaHora = fechaHora;
            this.motivocita = motivocita;
            this.diagnostico = diagnostico;
            this.paciente = paciente;   
            this.medico = medico;
        }

        public Cita()
        {
        }
    }
}
