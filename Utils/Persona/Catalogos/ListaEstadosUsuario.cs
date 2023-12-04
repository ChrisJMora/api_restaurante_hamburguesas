using api_restaurante_hamburguesas.Models.Persona.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Persona.Catalogos
{
    public class ListaEstadosUsuario
    {
        public List<EstadoUsuario> estadosUsuario = new List<EstadoUsuario>()
        {
            new EstadoUsuario { EstadoUsuarioId = 1, Estado = "Habililtado" },
            new EstadoUsuario { EstadoUsuarioId = 2, Estado = "Deshabilitado" },
        };
    }
}
