using api_restaurante_hamburguesas.Models.Persona.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Persona.Catalogos
{
    public class ListaGenerosCliente
    {
        public List<GeneroCliente> generos = new List<GeneroCliente>()
        {
            new GeneroCliente { GeneroId = 1, Genero = "Masculino" },
            new GeneroCliente { GeneroId = 2, Genero = "Femenino" }
        };

    }
}
