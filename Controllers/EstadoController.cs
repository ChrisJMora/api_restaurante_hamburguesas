using api_restaurante_hamburguesas.Auxiliaries.ApiMethods;
using api_restaurante_hamburguesas.Models;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Mvc;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly EstadoMethods _estadoMethods;

        public EstadoController(ApplicationContext context)
        {
            _context = context;
            _estadoMethods = new EstadoMethods(_context);
        }

        // GET: api/Estado
        [HttpGet("ObtenerEstados")]
        public async Task<ActionResult<Estado[]>>
            ObtenerEstados()
        {
            try
            {
                return Ok(await _estadoMethods.ObtenerEstados());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Estado
        [HttpGet("ObtenerEstado/{idEstado}")]
        public async Task<ActionResult<Estado>>
            ObtenerEstado(int idEstado)
        {
            try 
            {
                return Ok(await _estadoMethods.ObtenerEstado(idEstado)); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
