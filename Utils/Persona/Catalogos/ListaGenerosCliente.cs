using api_restaurante_hamburguesas.Models.Persona.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Persona.Catalogos
{
    public class ListaGenerosCliente
    {
        public List<GeneroCliente> generos = new List<GeneroCliente>()
        {
            new GeneroCliente { Id = 1, Etiqueta = "Masculino" },
            new GeneroCliente { Id = 2, Etiqueta = "Femenino" }
        };

    }
}
