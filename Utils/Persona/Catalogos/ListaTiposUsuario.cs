using api_restaurante_hamburguesas.Models.Persona.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Persona.Catalogos
{
    public class ListaTiposUsuario
    {
        public List<TipoUsuario> tiposUsuario = new List<TipoUsuario>()
        {
            new TipoUsuario() { Id = 1, Etiqueta = "Administrador" },
            new TipoUsuario() { Id = 2, Etiqueta = "Cliente" }
        };
    }
}
