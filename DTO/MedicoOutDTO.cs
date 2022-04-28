namespace MetaenlaceNet.DTO;

public class MedicoOutDTO : UsuarioDTO
{
    public string numColegiado { get; set; }
    public List<PacienteOutDTO> pacientes { get; set; } = new List<PacienteOutDTO>();
    public List<CitaOutDTO> citas { get; set; } = new List<CitaOutDTO>();

}
