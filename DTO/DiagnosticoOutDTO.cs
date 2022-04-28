namespace MetaenlaceNet.DTO
{
    public class DiagnosticoOutDTO
    {
        public long DiagnosticoId { get; set; }
        public string valoracionEspecialista { get; set; }
        public string enfermedad { get; set; }
        public CitaOutDTO cita { get; set; }


    }
}
