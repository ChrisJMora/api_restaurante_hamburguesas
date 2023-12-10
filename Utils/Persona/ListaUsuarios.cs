using api_restaurante_hamburguesas.Models.Persona;

namespace api_restaurante_hamburguesas.Utils.Persona
{
    public class ListaUsuarios
    {
        public readonly List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario()
            {
                Id = 1,
                IdTipoUsuario = 1,  // Administrador
                Nombre = "admin",
                FechaCreacion = DateTime.Now,
                FechaAcceso = DateTime.Now,
                IdEstadoUsuario = 1, // Habilitado
                IdCliente = null,
            },
            new Usuario()
            {
                Id = 2,
                IdTipoUsuario = 2,  // Cliente
                Nombre = "chris2003",
                FechaCreacion = DateTime.Now,
                FechaAcceso = DateTime.Now,
                IdEstadoUsuario = 1, // Habilitado
                IdCliente = 1,
            },
            new Usuario()
            {
                Id = 3,
                IdTipoUsuario = 2,  // Cliente
                Nombre = "xavier2007",
                FechaCreacion = DateTime.Now,
                FechaAcceso = DateTime.Now,
                IdEstadoUsuario = 1, // Habilitado
                IdCliente = 2,
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
