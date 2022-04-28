namespace MetaenlaceNet.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DiagnosticoId { get; set; }
        public string valoracionEspecialista { get; set; }
        public string enfermedad { get; set; }
        public Cita cita { get; set; }

        public Diagnostico(string valoracionEspecialista, string enfermedad, Cita cita)
        {
            this.valoracionEspecialista = valoracionEspecialista;
            this.enfermedad = enfermedad;
            this.cita = cita;
        }

        public Diagnostico()
        {
        }
    }
}
