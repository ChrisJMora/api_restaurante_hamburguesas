using Microsoft.AspNetCore.Mvc;
using API_restauranteHamburguesas.Data;
using api_restaurante_hamburguesas.Models.Persona;
using api_restaurante_hamburguesas.Models.Persona.Catalogos;
using api_restaurante_hamburguesas.Auxiliaries.ApiMethods;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UsuarioMethods _usuarioMethods;

        public UsuarioController(ApplicationContext context)
        {
            _context = context;
            _usuarioMethods = new UsuarioMethods(_context);
        }

        // GET: api/Usuario
        [HttpGet("ObtenerUsuario/{idUsuario}")]
        public async Task<ActionResult<Usuario>>
            ObtenerUsuario(int idUsuario)
        {
            try 
            {
                return Ok(await _usuarioMethods.ObtenerUsuario(idUsuario)); 
            }
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
            try 
            {
                return Ok(await _usuarioMethods.ObtenerCliente(idCliente)); 
            }
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
                return Ok(await _usuarioMethods.ObtenerUsuarios());
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
                return Ok(await _usuarioMethods.ObtenerClientes());
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
                return Ok(await _usuarioMethods.ObtenerGenerosCliente());
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
                return Ok(await _usuarioMethods.ObtenerGeneroCliente(idGeneroCliente));
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
                return Ok(await _usuarioMethods.ObtenerTiposUsuario());
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
            try 
            {
                return Ok(await _usuarioMethods.ObtenerTipoUsuario(idTipoUsuario)); 
            }
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
            try 
            { 
                return Ok(await _usuarioMethods.ObtenerUsuarios(caracteres)); 
            }
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
                return Ok(await _usuarioMethods.InicioSesionCliente(nombreUsuario, password));
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
                await _usuarioMethods.InicioSesionAdmin(nombreUsuario, password);
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
            try 
            {
                await _usuarioMethods.RegistroCuentaCliente(nombreUsuario, password, cliente);
                return Ok("Se registró la cuenta cliente correctamente");
            }
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
            try 
            {
                await _usuarioMethods.RegistroCuentaAdmin(nombreUsuario, password);
                return Ok("Se registró la cuenta administrador correctamente"); 
            }
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
            try 
            {
                await _usuarioMethods.ModificarUsuario(oldNombreUsuario, nombreUsuario, password, estadoUsuario);
                return Ok("Se modificó el usuario correctamente");
            }
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
                await _usuarioMethods.ModificarCliente(idCliente, nuevoCliente);
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
            try 
            {
                await _usuarioMethods.ModificarEstadoUsuario(nombreUsuario, idEstado);
                return Ok("Se modificó el estado del usuario correctamente");
            }
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
            try 
            {
                await _usuarioMethods.EliminarUsuario(nombreUsuario);
                return Ok("Se eliminó el usuario correctamente"); 
            }
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
                await _usuarioMethods.EliminarCliente(idCliente);
                return Ok("El cliente ha sido eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
