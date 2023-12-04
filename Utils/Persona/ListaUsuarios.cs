using api_restaurante_hamburguesas.Models.Persona;

namespace api_restaurante_hamburguesas.Utils.Persona
{
    public class ListaUsuarios
    {
        public readonly List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario()
            {
                UsuarioId = 1,
                TipoUsuarioId = 1,  // Administrador
                NombreUsuario = "admin",
                FechaCreacion = DateTime.Now,
                FechaAcceso = DateTime.Now,
                EstadoUsuarioId = 1, // Habilitado
                ClienteId = null,
            },
            new Usuario()
            {
                UsuarioId = 2,
                TipoUsuarioId = 2,  // Cliente
                NombreUsuario = "chris2003",
                FechaCreacion = DateTime.Now,
                FechaAcceso = DateTime.Now,
                EstadoUsuarioId = 1, // Habilitado
                ClienteId = 1,
            },
            new Usuario()
            {
                UsuarioId = 3,
                TipoUsuarioId = 2,  // Cliente
                NombreUsuario = "xavier2007",
                FechaCreacion = DateTime.Now,
                FechaAcceso = DateTime.Now,
                EstadoUsuarioId = 1, // Habilitado
                ClienteId = 2,
            }
        };

        public ListaUsuarios()
        {
            foreach (var usuario in usuarios)
            {
                usuario.EncriptarPassword("123");
            }
        }
    }
}
