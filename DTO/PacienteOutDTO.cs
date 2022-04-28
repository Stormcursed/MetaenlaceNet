namespace MetaenlaceNet.DTO
{
    public class PacienteOutDTO : UsuarioDTO
    {
        

        private string NSS { get; set; }
        private string numTarjeta { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public List<MedicoOutDTO> medicos { get; set; } = new List<MedicoOutDTO>();
        public List<CitaOutDTO> citas { get; set; } = new List<CitaOutDTO>();


    }
}
