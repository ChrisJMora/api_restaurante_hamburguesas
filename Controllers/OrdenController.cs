using api_restaurante_hamburguesas.Auxiliaries.ApiMethods;
using api_restaurante_hamburguesas.Models.Orden;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Mvc;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly OrdenMethods _ordenMethods;

        public OrdenController(ApplicationContext context)
        {
            _context = context;
            _ordenMethods = new OrdenMethods(_context);
        }

        // GET: api/Orden
        [HttpGet("ObtenerOrden/{idOrden}")]
        public async Task<ActionResult<Orden>>
            ObtenerOrden(int idOrden)
        {
            try
            {
                return await _ordenMethods.ObtenerOrden(idOrden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Orden
        [HttpGet("ObtenerNuevaOrden/{idCliente}")]
        public async Task<ActionResult<int>>
            ObtenerNuevaOrden(int idCliente)
        {
            try
            {
                return await _ordenMethods.ObtenerNuevaOrden(idCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Orden
        [HttpGet("ObtenerOrdenes")]
        public async Task<ActionResult<Orden[]>>
            ObtenerOrdenes()
        {
            try
            {
                return await _ordenMethods.ObtenerOrdenes();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Orden
        [HttpGet("ObtenerOrdenesCliente/{idCliente}")]
        public async Task<ActionResult<Orden[]>>
            ObtenerOrdenesCliente(int idCliente)
        {
            try
            {
                return await _ordenMethods.ObtenerOrdenesCliente(idCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/Orden
        [HttpPost("CrearOrden/{idCliente}")]
        public async Task<ActionResult>
            CrearOrden(int idCliente)
        {
            try
            {
                await _ordenMethods.CrearOrden(idCliente);
                return Ok("Orden creada con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
