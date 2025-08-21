using System.Linq;
using Teramantum.Interface;
using Teramantum.Model;

namespace Teramantum.Adapter
{
    public class ServicioBuscador : IServicioBuscador
    {
        private readonly String rutaArchivo = "Datasource/Servicios.csv";
        private readonly List<Servicio> servicios;

        public ServicioBuscador()
        {
            servicios = CargaDatos();
        }

        private List<Servicio> CargaDatos()
        {
            var resultados = new List<Servicio>();

            if (!File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException($"El archivo {rutaArchivo} no se encuentra disponible.");
            }

            try 
            {
                foreach (var linea in File.ReadLines(rutaArchivo).Skip(1))
                {
                    var valores = linea.Split(';');
                    var listaServicios = new List<Servicio>();

                    Console.WriteLine($"Procesando línea: {linea}");

                    if (valores.Length >= 18)
                    {
                        listaServicios.Add(new Servicio
                        {
                            depaNombre = valores[0].Trim(),
                            muniNombre = valores[1].Trim(),
                            clasePersonal = valores[14].Trim(),
                            nivel = valores[17].Trim()
                        });
                    }
                }
                Console.WriteLine($"termine");

            } catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }
            return null;
        }
        public List<Servicio> Buscardor(string depaNombre, string muniNombre, string clasePersona, string nivel)
        {
            Console.WriteLine($"Buscando servicios con: {depaNombre}, {muniNombre}, {clasePersona}, {nivel}");
            return servicios.Where(s =>
            s.depaNombre.Equals(depaNombre) ||
            s.muniNombre.Equals(muniNombre) ||
            s.clasePersonal.Equals(clasePersona) ||
            s.nivel.Equals(nivel)
        ).ToList();
        }
    }
}
