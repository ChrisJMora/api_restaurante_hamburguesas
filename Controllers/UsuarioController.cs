using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Identity;
using api_restaurante_hamburguesas.Models.Persona;
using Microsoft.IdentityModel.Tokens;
using api_restaurante_hamburguesas.Models.Persona.Catalogos;
using api_restaurante_hamburguesas.Models;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsuarioController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet("ObtenerUsuario/{idUsuario}")]
        public async Task<ActionResult<Usuario>>
            ObtenerUsuario(int idUsuario)
        {
            try { return Ok(await BuscarUsuario(idUsuario)); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("ObtenerCliente/{idCliente}")]
        public async Task<ActionResult<Cliente>>
            ObtenerCliente(int idCliente)
        {
            try { return Ok(await BuscarCliente(idCliente)); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("ObtenerUsuarios")]
        public async Task<ActionResult<Usuario[]>>
            ObtenerUsuarios()
        {
            try
            {
                Usuario[] usuarios = await _context.Usuarios
                    .OrderBy(b => b.TipoUsuarioId)
                    .OrderBy(b => b.NombreUsuario)
                    .ToArrayAsync();
                if (usuarios.Length == 0) throw new Exception("Lista de usuarios vacía");
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("ObtenerClientes")]
        public async Task<ActionResult<Cliente[]>>
            ObtenerClientes()
        {
            try
            {
                Cliente[] clientes = await _context.Clientes
                    .OrderBy(b => b.Nombre)
                    .ToArrayAsync();
                if (clientes.Length == 0) throw new Exception("Lista de clientes vacía");
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("ObtenerGenerosCliente")]
        public async Task<ActionResult<GeneroCliente[]>>
            ObtenerGenerosCliente()
        {
            try
            {
                GeneroCliente[] generos = await _context.Generos.ToArrayAsync();
                if (generos.Length == 0) throw new Exception("Lista de géneros cliente vacía");
                return Ok(generos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("ObtenerGeneroCliente/{idGeneroCliente}")]
        public async Task<ActionResult<GeneroCliente>>
            ObtenerGeneroCliente(int idGeneroCliente)
        {
            try
            {
                GeneroCliente? genero = await _context.Generos.FindAsync(idGeneroCliente);
                if (genero == null) throw new Exception("Género del cliente no encontrado");
                return Ok(genero);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("ObtenerTiposUsuario")]
        public async Task<ActionResult<TipoUsuario[]>>
            ObtenerTiposUsuario()
        {
            try
            {
                TipoUsuario[] tiposUsuarios = await _context.TiposUsuario.ToArrayAsync();
                if (tiposUsuarios.Length == 0) throw new Exception("Lista de tipos de usuario vacía");
                return Ok(tiposUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("ObtenerTipoUsuario/{idTipoUsuario}")]
        public async Task<ActionResult<TipoUsuario>>
            ObtenerTipoUsuario(int idTipoUsuario)
        {
            try { return Ok(await BuscarTipoUsuario(idTipoUsuario)); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("ObtenerUsuarios/{caracteres}")]
        public async Task<ActionResult<Usuario[]>>
            ObtenerUsuarios(string caracteres)
        {
            try { return Ok(await BuscarUsuarios(caracteres)); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("IncioSesionCliente/{nombreUsuario},{password}")]
        public async Task<ActionResult<Cliente>>
            InicioSesionCliente(string nombreUsuario, string password)
        {
            try
            {
                Usuario usuario = await IniciarSesion(nombreUsuario, password);
                if (usuario.EstadoUsuarioId == 2)
                    throw new Exception("Usuario Deshabilitado");
                if (usuario.TipoUsuarioId == 1)
                    throw new Exception("Acceso Denegado");
                int? clienteId = usuario.ClienteId;
                if (clienteId == null)
                    throw new Exception($"No hay un cliente asociado al usuario: {nombreUsuario}");
                usuario.FechaAcceso = new FechaHora().ObtenerFechaHoraLocal();
                await GuardarCambios();
                return Ok(await BuscarCliente((int)clienteId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("IncioSesionAdmin/{nombreUsuario},{password}")]
        public async Task<ActionResult>
            InicioSesionAdmin(string nombreUsuario, string password)
        {
            try
            {
                Usuario usuario = await IniciarSesion(nombreUsuario, password);
                if (usuario.EstadoUsuarioId == 2)
                    throw new Exception("Usuario Deshabilitado");
                if (usuario.TipoUsuarioId == 2)
                    throw new Exception("Acceso denegado");
                usuario.FechaAcceso = new FechaHora().ObtenerFechaHoraLocal();
                await GuardarCambios();
                return Ok($"Bienvenido, {nombreUsuario}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Usuario
        [HttpPost("RegistroCuentaCliente/{nombreUsuario},{password}")]
        public async Task<ActionResult>
            RegistroCuentaCliente(string nombreUsuario, string password, Cliente cliente)
        {
            try { return await RegistrarCuenta(nombreUsuario, password, cliente); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Usuario
        [HttpPost("RegistroCuentaAdmin/{nombreUsuario},{password}")]
        public async Task<ActionResult>
            RegistroCuentaAdmin(string nombreUsuario, string password)
        {
            try { return await RegistrarCuenta(nombreUsuario, password); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Usuario
        [HttpPut("ModificarUsuario/{oldNombreUsuario},{nombreUsuario},{password},{estadoUsuario}")]
        public async Task<ActionResult>
            ModificarUsuario(string oldNombreUsuario, string nombreUsuario, string password, int estadoUsuario)
        {
            try { return await ModificarCredenciales(oldNombreUsuario,
                nombreUsuario, password, estadoUsuario); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Usuario
        [HttpPut("ModificarCliente/{idCliente}")]
        public async Task<ActionResult>
            ModificarCliente(int idCliente, Cliente nuevoCliente)
        {
            try
            {
                Cliente cliente = await BuscarCliente(idCliente);

                cliente.Nombre = nuevoCliente.Nombre;
                cliente.Apellido = nuevoCliente.Apellido;
                cliente.FechaNacimiento = nuevoCliente.FechaNacimiento;
                cliente.GeneroId = nuevoCliente.GeneroId;

                await GuardarCambios();
                return Ok("Se ha modificado el cliente con éxito");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: apiUsuario
        [HttpPut("ModificarEstadoUsuario/{nombreUsuario},{idEstado}")]
        public async Task<ActionResult>
            ModificarEstadoUsuario(string nombreUsuario, int idEstado)
        {
            try { return await ModificarEstadoCuenta(nombreUsuario, idEstado); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Usuario
        [HttpDelete("EliminarUsuario/{nombreUsuario}")]
        public async Task<ActionResult>
            EliminarUsuario(string nombreUsuario)
        {
            try { return await EliminarCuenta(nombreUsuario); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Usuario
        [HttpDelete("EliminarCliente/{idCliente}")]
        public async Task<ActionResult>
            EliminarCliente(int idCliente)
        {
            try 
            {
                Cliente cliente = await BuscarCliente(idCliente);
                _context.Clientes.Remove(cliente);
                await GuardarCambios();
                return Ok("El cliente ha sido eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET

        private async Task<Usuario>
            IniciarSesion(string nombreUsuario, string password)
        {
            VerificarCredenciales(nombreUsuario, password);
            Usuario usuario = await BuscarUsuario(nombreUsuario);
            if (!PasswordValida(usuario.SaltPassword, usuario.PasswordUsuario, password))
                throw new Exception("La contraseña es incorrecta");
            return usuario;
        }

        private async Task<Usuario>
            BuscarUsuario(int idUsuario)
        {
            // Busca si el usuario se encuentra en la base de datos
            Usuario? usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");
            return usuario;
        }

        private async Task<TipoUsuario>
            BuscarTipoUsuario(int idTipoUsuario)
        {
            // Busca si el tipo del usuario se encuentra en la base de datos
            TipoUsuario? tipoUsuario = await _context.TiposUsuario.FindAsync(idTipoUsuario);
            if (tipoUsuario == null)
                throw new Exception("Nombre de usuario no encontrado");
            return tipoUsuario;
        }

        private async Task<Usuario>
            BuscarUsuario(string nombreUsuario)
        {
            // Busca si el usuario se encuentra en la base de datos
            Usuario? usuario =
                await _context.Usuarios
                .Where(b => b.NombreUsuario.Equals(nombreUsuario)).
                FirstOrDefaultAsync();
            if (usuario == null)
                throw new Exception("Usuario no encontrado");
            return usuario;
        }

        private async Task<Usuario[]>
            BuscarUsuarios(string caracteres)
        {
            // Busca los usuarios que contengan los nombreUsuario ingresados
            Usuario[]? usuarios =
                await _context.Usuarios
                .Where(b => b.NombreUsuario.Contains(caracteres))
                .OrderBy(b => b.TipoUsuarioId)
                .OrderBy(b => b.NombreUsuario)
                .ToArrayAsync();
            if (usuarios == null)
                throw new Exception("Usuarios no encontrados");
            return usuarios;
        }

        private async Task<Cliente>
            BuscarCliente(int idCliente)
        {
            //  Busca el cliente en la base de datos
            Cliente? cliente =
                await _context.Clientes.FindAsync(idCliente);
            if (cliente == null)
                throw new Exception("Cliente no encontrado");
            return cliente;
        }

        // POST

        private async Task<ActionResult>
            RegistrarCuenta(string nombreUsuario, string password, Cliente cliente)
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
            return Ok("Usuario registrado correctamente");
        }

        private async Task<ActionResult>
            RegistrarCuenta(string nombreUsuario, string password)
        {
            VerificarCredenciales(nombreUsuario, password);
            if (await UsuarioRepetido(nombreUsuario))
                throw new Exception("El administrador ya se encuentra registrado");
            // crea un nuevo usuario administrador
            Usuario usuario = CrearUsuario(nombreUsuario, password, 1);
            // registra al usuario en la base de datos
            await _context.Usuarios.AddAsync(usuario);
            await GuardarCambios();
            return Ok("Usuario registrado correctamente");
        }

        // PUT
            
        private async Task<ActionResult>
            ModificarCredenciales(string oldNombreUsuario, string nombreUsuario, string password, int estadoUsuario)
        {
            /*Usuario usuario = await BuscarUsuario(nombreUsuarioAdmin);
            if (usuario.EstadoUsuarioId == 2)
                throw new Exception("Usuario Deshabilitado");
            if (usuario.TipoUsuarioId == 2)
                throw new Exception("Acceso denegado");
            if (!PasswordValida(usuario.SaltPassword, usuario.PasswordUsuario, passwordAdmin))
                throw new Exception("Contraseña incorrecta");*/
            Usuario oldUsuario = await BuscarUsuario(oldNombreUsuario);
            oldUsuario.NombreUsuario = nombreUsuario;
            oldUsuario.EncriptarPassword(password);
            oldUsuario.EstadoUsuarioId = estadoUsuario;
            await GuardarCambios();
            return Ok("El usuario ha sido modificado con éxito");
        }

        private async Task<ActionResult>
            ModificarEstadoCuenta(string nombreUsuario, int idEstado)
        {
/*            Usuario usuarioAdmin = await BuscarUsuario(nombreUsuarioAdmin);
            if (usuarioAdmin.EstadoUsuarioId == 2)
                throw new Exception("Usuario Deshabilitado");
            if (usuarioAdmin.TipoUsuarioId == 2)
                throw new Exception("Acceso denegado");
            if (!PasswordValida(usuarioAdmin.SaltPassword, usuarioAdmin.PasswordUsuario, passwordAdmin))
                throw new Exception("Contraseña incorrecta");*/
            Usuario aHabilitar = await BuscarUsuario(nombreUsuario);
            aHabilitar.EstadoUsuarioId = idEstado;
            await GuardarCambios();
            return Ok("El estado del usuario ha sido modificado correctamente");
        }
        
        // DELETE

        private async Task<ActionResult>
            EliminarCuenta(string nombreUsuario)
        {
            /*Usuario usuarioAdmin = await BuscarUsuario(nombreUsuarioAdmin);
            if (usuarioAdmin.EstadoUsuarioId == 2)
                throw new Exception("Usuario Deshabilitado");
            if (usuarioAdmin.TipoUsuarioId == 2)
                throw new Exception("Acceso denegado");
            if (!PasswordValida(usuarioAdmin.SaltPassword, usuarioAdmin.PasswordUsuario, passwordAdmin))
                throw new Exception("Contraseña incorrecta");*/
            Usuario aEliminar = await BuscarUsuario(nombreUsuario);
            _context.Usuarios.Remove(aEliminar);
            await GuardarCambios();
            return Ok("El usuario ha sido eliminado correctamente");
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
                Usuario? usuario = await BuscarUsuario(nombreUsuario);
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
                TipoUsuarioId = tipoUsuario,  
                NombreUsuario = nombreUsuario,
                FechaCreacion = new FechaHora().ObtenerFechaHoraLocal(),
                FechaAcceso = new FechaHora().ObtenerFechaHoraLocal(),
                EstadoUsuarioId = 1, // Habilitado
                ClienteId = null,
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
