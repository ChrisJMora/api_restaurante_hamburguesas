using api_restaurante_hamburguesas.Models.Orden;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : Controller
    {
        private readonly ApplicationContext _context;

        public OrdenController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Orden
        [HttpGet("ObtenerOrdenes")]
        public async Task<ActionResult<Orden[]>>
            ObtenerOrdenes()
        {
            try
            {
                Orden[] ordenes = await _context.Ordenes.ToArrayAsync();
                if (ordenes.Length == 0) throw new Exception("No hay ordenes disponibles");
                return ordenes;
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
                Orden[] ordenes = await _context.Ordenes
                    .Where(b => b.ClienteId_Orden == idCliente)
                    .ToArrayAsync();
                if (ordenes.Length == 0) throw new Exception($"No hay ordenes asociadas al cliente con id: {idCliente}");
                return ordenes;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
