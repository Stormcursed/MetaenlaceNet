using MetaenlaceNet.DTO;
using MetaenlaceNet.Entity;

namespace MetaenlaceNet.Service
{
    public interface ICitaService
    {
        public Cita? SaveCita(CitaInDTO citaDTO);
        public void DeleteCita(long Id);
        public Cita? GetCitaById(long Id);

        public List<CitaOutDTO> GetCitas();

    }
}
