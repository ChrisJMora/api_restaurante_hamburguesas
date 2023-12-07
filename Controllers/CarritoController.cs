using Microsoft.AspNetCore.Mvc;
using API_restauranteHamburguesas.Data;
using api_restaurante_hamburguesas.Models.Orden;
using api_restaurante_hamburguesas.Auxiliaries.ApiMethods;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly CarritoMethods _carritoMethods;

        public CarritoController(ApplicationContext context)
        {
            _context = context;
            _carritoMethods = new CarritoMethods(_context);
        }
        
        // GET: api/Carrito
        [HttpGet("ObtenerProducto/{idProducto}")]
        public async Task<ActionResult<ProductoCarrito>> 
            ObtenerProducto(int idProducto)
        {
            try 
            {
                return Ok(await _carritoMethods.ObtenerProducto(idProducto)); 
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Carrito
        [HttpGet("ObtenerComidaCarrito/{idComidaCarrito}")]
        public async Task<ActionResult<ComidaCarrito>>
            ObtenerComidaCarrito(int idComidaCarrito)
        {
            try
            {
                return Ok(await _carritoMethods.ObtenerComidaCarrito(idComidaCarrito));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Carrito
        [HttpGet("ObtenerComboCarrito/{idComboCarrito}")]
        public async Task<ActionResult<ComboCarrito>>
            ObtenerComboCarrito(int idComboCarrito)
        {
            try
            {
                return Ok(await _carritoMethods.ObtenerComboCarrito(idComboCarrito));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Carrito
        [HttpGet("ObtenerComidas/{idOrden}")]
        public async Task<ActionResult<ComidaCarrito[]>>
            ObtenerComidas(int idOrden)
        {
            try
            {
                return Ok(await _carritoMethods.ObtenerComidas(idOrden));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Carrito
        [HttpGet("ObtenerCombos/{idOrden}")]
        public async Task<ActionResult<ComboCarrito[]>>
            ObtenerCombos(int idOrden)
        {
            try 
            {
                return Ok(await _carritoMethods.ObtenerCombos(idOrden)); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Carrito
        [HttpGet("ObtenerComidasCombo/{idComboCarrito}")]
        public async Task<ActionResult<ComidaCarrito[]>>
            ObtenerComidasCombo(int idComboCarrito)
        {
            try
            {
                return Ok(await _carritoMethods.ObtenerComidasCombo(idComboCarrito));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Carrito
        [HttpGet("CalcularTotalCombo/{idComboCarrito}")]
        public async Task<ActionResult<double>>
            CalcularTotalCombo(int idComboCarrito)
        {
            try
            {
                return Ok(await _carritoMethods.CalcularTotalCombo(idComboCarrito));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Carrito
        [HttpGet("CalcularTotalOrden/{idOrden}")]
        public async Task<ActionResult<double>>
            CalcularTotalOrden(int idOrden)
        {
            try
            {
                return Ok(await _carritoMethods.CalcularTotalOrden(idOrden));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Carrito/5
        [HttpPost("AgregarComboCarrito/{idOrden},{idComboCarrito},{cantidad}")]
        public async Task<ActionResult>
            AgregarComboCarrito(int idOrden, int idCombo, int cantidad, int[] idComidas)
        {
            try 
            {
                await _carritoMethods.AgregarComboCarrito(idOrden, idCombo, cantidad, idComidas);
                return Ok("El combo fue agregado correctamente al carrito"); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Carrito/5
        [HttpPost("AgregarComidaCarrito/{idOrden},{idComida},{cantidad}")]
        public async Task<ActionResult>
            AgregarComidaCarrito(int idOrden, int idComida, int cantidad)
        {
            try 
            { 
                await _carritoMethods.AgregarComidaCarrito(idOrden,idComida, cantidad);
                return Ok("La comida fue agregada correctamente al carrito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Carrito/5
        [HttpPut("ModificarCantidadProducto/{idProducto},{cantidad}")]
        public async Task<ActionResult>
            ModificarCantidadProducto(int idProducto, int cantidad)
        {
            try 
            { 
                await _carritoMethods.ModificarCantidad(idProducto, cantidad);
                return Ok("Se modificó la cantidad del producto correctamente"); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Carrito/5
        [HttpPut("AumentarCantidadProducto/{idProducto}")]
        public async Task<ActionResult>
            AumentarCantidadProducto(int idProducto)
        {
            try 
            {
                await _carritoMethods.AumentarCantidad(idProducto);
                return Ok("Se aumentó una unidad a la cantidad del producto correctamente"); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Carrito/5
        [HttpPut("DisminuirCantidadProducto/{idProducto}")]
        public async Task<ActionResult>
            DisminuirCantidadProducto(int idProducto)
        {
            try 
            { 
                await _carritoMethods.DisminuirCantidad(idProducto);
                return Ok("Se disminuyó una unidad a la cantidad del producto correctamente"); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Carrito/5
        [HttpDelete("EliminarComboCarrito/{idProducto}")]
        public async Task<ActionResult>
            EliminarComboCarrito(int idComboCarrito)
        {
            try
            {
                await _carritoMethods.EliminarCombo(idComboCarrito);
                return Ok("Se eliminó el combo del carrito correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Carrito/5
        [HttpDelete("EliminarComidaCarrito/{idProducto}")]
        public async Task<ActionResult>
            EliminarComidaCarrito(int idComidaCarrito)
        {
            try
            {
                await _carritoMethods.EliminarComida(idComidaCarrito);
                return Ok("Se eliminó la comida del carrito correctametne");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}