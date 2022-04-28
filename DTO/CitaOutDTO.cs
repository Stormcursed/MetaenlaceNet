namespace MetaenlaceNet.DTO
{
    public class CitaOutDTO
    {
        public long CitaId { get; set; }
        public DateTime fechaHora { get; set; }
        public string motivocita { get; set; }

        public DiagnosticoOutDTO diagnostico { get; set; }
        public PacienteOutDTO paciente { get; set; }
        public MedicoOutDTO medico { get; set; }
    }
}
