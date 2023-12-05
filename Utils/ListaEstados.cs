using api_restaurante_hamburguesas.Models;

namespace api_restaurante_hamburguesas.Utils
{
    public class ListaEstados
    {
        public List<Estado> estados = new List<Estado>()
        {
            new Estado { EstadoUsuarioId = 1, Nombre = "Habililtado" },
            new Estado { EstadoUsuarioId = 2, Nombre = "Deshabilitado" },
        };
    }
}
