using api_restaurante_hamburguesas.Models;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : Controller
    {
        private readonly ApplicationContext _context;

        public EstadoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet("ObtenerEstadosUsuario")]
        public async Task<ActionResult<Estado[]>>
            ObtenerEstadosUsuario()
        {
            try
            {
                Estado[] estadosUsuario = await _context.Estados.ToArrayAsync();
                if (estadosUsuario.Length == 0) throw new Exception("Lista de estados de usuario vacía");
                return Ok(estadosUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario
        [HttpGet("ObtenerEstadoUsuario/{idEstado}")]
        public async Task<ActionResult<Estado>>
            ObtenerEstadoUsuario(int idEstadoUsuario)
        {
            try { return Ok(await BuscarEstado(idEstadoUsuario)); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<Estado>
            BuscarEstado(int idEstado)
        {
            // Busca si el estado del usuario se encuentra en la base de datos
            Estado? estado = await _context.Estados.FindAsync(idEstado);
            if (estado == null)
                throw new Exception("Estado no encontrado");
            return estado;
        }

    }
}
