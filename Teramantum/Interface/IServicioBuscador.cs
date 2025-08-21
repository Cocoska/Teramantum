using Teramantum.Model;

namespace Teramantum.Interface
{
    public interface IServicioBuscador
    {
        List<Servicio> Buscardor(
            String depaNombre,
            String MuniNombre,
            String ClasePersona,
            String nivel);
    }
}