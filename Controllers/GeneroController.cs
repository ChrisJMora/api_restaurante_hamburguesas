using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_restauranteHamburguesas.Data;
using api_restaurante_hamburguesas.Models.Persona.Catalogos;
using api_restaurante_hamburguesas.Models.Persona;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public GeneroController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Genero
        [HttpGet("ObtenerGeneros")]
        public async Task<ActionResult<IEnumerable<GeneroCliente>>> ObtenerGeneros()
        {
            try
            {
                GeneroCliente[] generos = await _context.Generos.ToArrayAsync();
                if (generos.Length == 0) throw new Exception("No hay generos existentes");
                return Ok(generos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
