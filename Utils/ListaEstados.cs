using api_restaurante_hamburguesas.Models;

namespace api_restaurante_hamburguesas.Utils
{
    public class ListaEstados
    {
        public List<Estado> estados = new List<Estado>()
        {
            new Estado { Id = 1, Etiqueta = "Habililtado" },
            new Estado { Id = 2, Etiqueta = "Deshabilitado" },
        };
    }
}
