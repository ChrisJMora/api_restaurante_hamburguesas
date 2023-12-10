using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Identity;
using api_restaurante_hamburguesas.Models.Persona;
using Microsoft.IdentityModel.Tokens;
using api_restaurante_hamburguesas.Models.Persona.Catalogos;
using api_restaurante_hamburguesas.Auxiliaries;

namespace api_restaurante_hamburguesas.Auxiliaries.ApiMethods
{
    public class UsuarioMethods : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsuarioMethods(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Usuario>
            ObtenerUsuario(int idUsuario)
        {
            Usuario? usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");
            return usuario;
        }

        private async Task<Usuario>
            ObtenerUsuario(string nombreUsuario)
        {
            Usuario? usuario =
                await _context.Usuarios
                .Where(b => b.Nombre.Equals(nombreUsuario)).
                FirstOrDefaultAsync();
            if (usuario == null)
                throw new Exception("Usuario no encontrado");
            return usuario;
        }

        public async Task<Cliente>
            ObtenerCliente(int idCliente)
        {
            Cliente? cliente =
            await _context.Clientes.FindAsync(idCliente);
            if (cliente == null)
                throw new Exception("Cliente no encontrado");
            return cliente;
        }

        public async Task<Usuario[]>
            ObtenerUsuarios()
        {
            Usuario[] usuarios = await _context.Usuarios
            .OrderBy(b => b.IdTipoUsuario)
            .OrderBy(b => b.Nombre)
            .ToArrayAsync();
            if (usuarios.Length == 0) throw new Exception("Lista de usuarios vacía");
            return usuarios;
        }

        public async Task<Cliente[]>
            ObtenerClientes()
        {
            Cliente[] clientes = await _context.Clientes
                .OrderBy(b => b.Nombre)
                .ToArrayAsync();
            if (clientes.Length == 0) throw new Exception("Lista de clientes vacía");
            return clientes;
        }

        public async Task<GeneroCliente[]>
            ObtenerGenerosCliente()
        {
            GeneroCliente[] generos = await _context.Generos.ToArrayAsync();
            if (generos.Length == 0) throw new Exception("Lista de géneros cliente vacía");
            return generos;
        }

        public async Task<GeneroCliente>
            ObtenerGeneroCliente(int idGeneroCliente)
        {
            GeneroCliente? genero = await _context.Generos.FindAsync(idGeneroCliente);
            if (genero == null) throw new Exception("Género del cliente no encontrado");
            return genero;
        }

        public async Task<TipoUsuario[]>
            ObtenerTiposUsuario()
        {
            TipoUsuario[] tiposUsuarios = await _context.TiposUsuario.ToArrayAsync();
            if (tiposUsuarios.Length == 0) throw new Exception("Lista de tipos de usuario vacía");
            return tiposUsuarios;
        }

        public async Task<TipoUsuario>
            ObtenerTipoUsuario(int idTipoUsuario)
        {
            TipoUsuario? tipoUsuario = await _context.TiposUsuario.FindAsync(idTipoUsuario);
            if (tipoUsuario == null)
                throw new Exception("Etiqueta de usuario no encontrado");
            return tipoUsuario;
        }

        public async Task<Usuario[]>
            ObtenerUsuarios(string caracteres)
        {
            Usuario[]? usuarios =
            await _context.Usuarios
            .Where(b => b.Nombre.Contains(caracteres))
            .OrderBy(b => b.IdTipoUsuario)
            .OrderBy(b => b.Nombre)
            .ToArrayAsync();
            if (usuarios == null)
                throw new Exception("Usuarios no encontrados");
            return usuarios;
        }

        public async Task<Cliente>
            InicioSesionCliente(string nombreUsuario, string password)
        {
            VerificarCredenciales(nombreUsuario, password);
            Usuario usuario = await ObtenerUsuario(nombreUsuario);
            if (!PasswordValida(usuario.SaltPassword, usuario.Password, password))
                throw new Exception("La contraseña es incorrecta");
            if (usuario.IdEstadoUsuario == 2)
                throw new Exception("Usuario Deshabilitado");
            if (usuario.IdTipoUsuario == 1)
                throw new Exception("Acceso Denegado");
            int? clienteId = usuario.IdCliente;
            if (clienteId == null)
                throw new Exception($"No hay un cliente asociado al usuario: {nombreUsuario}");
            usuario.FechaAcceso = new FechaHora().ObtenerFechaHoraLocal();
            await GuardarCambios();
            return await ObtenerCliente((int)clienteId);
        }

        public async Task
            InicioSesionAdmin(string nombreUsuario, string password)
        {
            VerificarCredenciales(nombreUsuario, password);
            Usuario usuario = await ObtenerUsuario(nombreUsuario);
            if (!PasswordValida(usuario.SaltPassword, usuario.Password, password))
                throw new Exception("La contraseña es incorrecta");
            if (usuario.IdEstadoUsuario == 2)
                throw new Exception("Usuario Deshabilitado");
            if (usuario.IdTipoUsuario == 2)
                throw new Exception("Acceso denegado");
            usuario.FechaAcceso = new FechaHora().ObtenerFechaHoraLocal();
            await GuardarCambios();
        }

        public async Task
            RegistroCuentaCliente(string nombreUsuario, string password, Cliente cliente)
        {
            VerificarCredenciales(nombreUsuario, password);
            if (await UsuarioRepetido(nombreUsuario))
                throw new Exception("El cliente ya se encuentra registrado");
            // crea un nuevo usuario cliente
            Usuario usuario = CrearUsuario(nombreUsuario, password, 2);
            // ata el cliente al nuevo usuario
            cliente.Usuario = usuario;
            // registra al cliente y usuario en la base de datos
            await _context.Usuarios.AddAsync(usuario);
            await _context.Clientes.AddAsync(cliente);
            await GuardarCambios();
        }

        public async Task
            RegistroCuentaAdmin(string nombreUsuario, string password)
        {
            VerificarCredenciales(nombreUsuario, password);
            if (await UsuarioRepetido(nombreUsuario))
                throw new Exception("El administrador ya se encuentra registrado");
            // crea un nuevo usuario administrador
            Usuario usuario = CrearUsuario(nombreUsuario, password, 1);
            // registra al usuario en la base de datos
            await _context.Usuarios.AddAsync(usuario);
            await GuardarCambios();
        }

        public async Task
            ModificarUsuario(string oldNombreUsuario, string nombreUsuario, string password, int estadoUsuario)
        {
            Usuario oldUsuario = await ObtenerUsuario(oldNombreUsuario);
            oldUsuario.Nombre = nombreUsuario;
            oldUsuario.EncriptarPassword(password);
            oldUsuario.IdEstadoUsuario = estadoUsuario;
            await GuardarCambios();
        }

        public async Task
            ModificarCliente(int idCliente, Cliente nuevoCliente)
        {
            Cliente cliente = await ObtenerCliente(idCliente);
            cliente.Nombre = nuevoCliente.Nombre;
            cliente.Apellido = nuevoCliente.Apellido;
            cliente.FechaNacimiento = nuevoCliente.FechaNacimiento;
            cliente.IdGenero = nuevoCliente.IdGenero;
            await GuardarCambios();
        }

        public async Task
            ModificarEstadoUsuario(string nombreUsuario, int idEstado)
        {
            Usuario aHabilitar = await ObtenerUsuario(nombreUsuario);
            aHabilitar.IdEstadoUsuario = idEstado;
            await GuardarCambios();
        }

        public async Task
            EliminarUsuario(string nombreUsuario)
        {
            Usuario aEliminar = await ObtenerUsuario(nombreUsuario);
            _context.Usuarios.Remove(aEliminar);
            await GuardarCambios();
        }

        public async Task
            EliminarCliente(int idCliente)
        {
            Cliente cliente = await ObtenerCliente(idCliente);
            _context.Clientes.Remove(cliente);
            await GuardarCambios();
        }

        // VERIFICACIONES

        private void
            VerificarCredenciales(string nombreUsuario, string password)
        {
            // Verifica que las credenciales no estén vacías
            if (nombreUsuario.IsNullOrEmpty() || password.IsNullOrEmpty())
                throw new Exception("Campos vacíos");
        }

        private async Task<bool>
            UsuarioRepetido(string nombreUsuario)
        {
            try
            {
                Usuario? usuario = await ObtenerUsuario(nombreUsuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool
            PasswordValida(string salt, string hashedPassword, string providedPassword)
        {
            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

            // Valida el passwordAdmin
            PasswordVerificationResult cuentaValida = passwordHasher.
                VerifyHashedPassword(null, hashedPassword, salt + providedPassword);

            return cuentaValida == PasswordVerificationResult.Success;
        }

        // MÉTODOS AUXILIARES

        private Usuario
            CrearUsuario(string nombreUsuario, string password, int tipoUsuario)
        {
            Usuario usuario = new Usuario()
            {
                IdTipoUsuario = tipoUsuario,  
                Nombre = nombreUsuario,
                FechaCreacion = new FechaHora().ObtenerFechaHoraLocal(),
                FechaAcceso = new FechaHora().ObtenerFechaHoraLocal(),
                IdEstadoUsuario = 1, // Habilitado
                IdCliente = null,
            };
            usuario.EncriptarPassword(password);
            return usuario;
        }

        private async Task
            GuardarCambios()
        {
            await _context.SaveChangesAsync();
        }
    }
}
