using api_restaurante_hamburguesas.Models;
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
        [HttpGet("ObtenerOrden/{idOrden}")]
        public async Task<ActionResult<Orden>>
            ObtenerOrden(int idOrden)
        {
            try
            {
                Orden? orden = await _context.Ordenes.FindAsync(idOrden);
                if (orden == null) throw new Exception("Orden no encontrada");
                return orden;
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
                    .Where(b => b.ClienteId == idCliente)
                    .ToArrayAsync();
                if (ordenes.Length == 0) throw new Exception($"No hay ordenes asociadas al cliente con id: {idCliente}");
                return ordenes;
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
                Orden orden = new Orden()
                {
                    ClienteId = idCliente,
                    Fecha = new FechaHora().ObtenerFechaHoraLocal()
                };
                await _context.Ordenes.AddAsync(orden);
                await _context.SaveChangesAsync();
                return Ok("Orden creada con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
