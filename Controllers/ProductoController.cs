using api_restaurante_hamburguesas.Auxiliaries.ApiMethods;
using api_restaurante_hamburguesas.Models.Productos;
using api_restaurante_hamburguesas.Models.Productos.Catalogos;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Mvc;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ProductoMethods _productoMethods;

        public ProductoController(ApplicationContext context)
        {
            _context = context;
            _productoMethods = new ProductoMethods(_context);
        }

        // GET: api/Productos
        [HttpGet("ObtenerComidas")]
        public async Task<ActionResult<Comida[]>> 
            ObtenerComidas()
        {
            try
            {
                return Ok(await _productoMethods.ObtenerComidas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Productos
        [HttpGet("ObtenerCombos")]
        public async Task<ActionResult<Combo[]>> 
            ObtenerCombos()
        {
            try
            {
                return Ok(await _productoMethods.ObtenerCombos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Productos
        [HttpGet("ObtenerCategoriasComida")]
        public async Task<ActionResult<CategoriaComida[]>>
            ObtenerCategoriasComida()
        {
            try
            {
                return Ok(await _productoMethods.ObtenerCategoriasComida());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Productos
        [HttpGet("ObtenerCategoriasCombo")]
        public async Task<ActionResult<CategoriaCombo[]>>
            ObtenerCategoriasCombo()
        {
            try
            {
                return Ok(await _productoMethods.ObtenerCategoriasCombo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("ObtenerComidaCarrito/{idComida}")]
        public async Task<ActionResult<Comida>>
            ObtenerComida(int idComida)
        {
            try
            {
                return Ok(await _productoMethods.ObtenerComida(idComida));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("ObtenerCombo/{idCombo}")]
        public async Task<ActionResult<Combo>>
            ObtenerCombo(int idCombo)
        {
            try
            {
                return Ok(await _productoMethods.ObtenerCombo(idCombo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("ObtenerCategoriaComida/{idCategoriaComida}")]
        public async Task<ActionResult<CategoriaComida>>
            ObtenerCategoriaComida(int idCategoriaComida)
        {
            try
            {
                return Ok(await _productoMethods.ObtenerCategoriaComida(idCategoriaComida));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("ObtenerCategoriaCombo/{idCategoriaCombo}")]
        public async Task<ActionResult<CategoriaCombo>>
            ObtenerCategoriaCombo(int idCategoriaCombo)
        {
            try
            {
                return Ok(await _productoMethods.ObtenerCategoriaCombo(idCategoriaCombo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("ObtenerComidasCombo/{idCombo}")]
        public async Task<ActionResult<ComboComida[]>>
            ObtenerComidasCombo(int idCombo)
        {
            try
            {
                return Ok(await _productoMethods.ObtenerComidasCombo(idCombo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("FiltrarComidas/{idCategoriaComida}")]
        public async Task<ActionResult<Comida[]>>
            FiltrarComidas(int idCategoriaComida)
        {
            try
            {
                return Ok(await _productoMethods.FiltrarComidas(idCategoriaComida));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("FiltrarCombos/{idCategoriaComvo}")]
        public async Task<ActionResult<Combo[]>>
            FiltrarCombos(int idCategoriaCombo)
        {
            try
            {
                return Ok(await _productoMethods.FiltrarCombos(idCategoriaCombo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Producto
        [HttpPost("AgregarComida/{nombre},{descripcion},{precio},{idCategoriaComida}")]
        public async Task<ActionResult>
            AgregarComida(string nombre, string descripcion, double precio, int idCategoriaComida)
        {
            try
            {
                await _productoMethods.AgregarComida(nombre, descripcion, precio, idCategoriaComida);
                return Ok("Comida agregada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Producto
        [HttpPost("AgregarCombo/{nombre},{descripcion},{descuento},{idCategoriaCombo}")]
        public async Task<ActionResult>
            AgregarCombo(string nombre, string descripcion, double descuento, int idCategoriaCombo)
        {
            try
            {
                await _productoMethods.AgregarCombo(nombre, descripcion, descuento, idCategoriaCombo);
                return Ok("Combo agregado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Producto
        [HttpPost("AgregarComidaCombo/{idCombo},{idComida},{cantidad}")]
        public async Task<ActionResult>
            AgregarComidaCombo(int idCombo, int idComida, int cantidad)
        {
            try
            {
                await _productoMethods.AgregarComidaCombo(idCombo, idComida, cantidad);
                return Ok($"La comida {idComida} fue agregado al combo {idCombo} correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        // POST: api/Producto
        [HttpPost("AgregarCategoriaComida/{nombre}")]
        public async Task<ActionResult>
            AgregarCategoriaComida(string nombre)
        {
            try
            {
                await _productoMethods.AgregarCategoriaComida(nombre);
                return Ok($"La categoria comida ha sido agregada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        // POST: api/Producto
        [HttpPost("AgregarCategoriaCombo/{nombre}")]
        public async Task<ActionResult>
            AgregarCategoriaCombo(string nombre)
        {
            try
            {
                await _productoMethods.AgregarCategoriaCombo(nombre);
                return Ok($"La categoria combo ha sido agregada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        // PUT: api/Producto
        [HttpPut("ModificarComida/{idComida},{nombre},{descripcion},{precio},{idCategoriaComida}")]
        public async Task<ActionResult>
            ModificarComida(int idComida, string nombre, string descripcion, double precio, int idCategoriaComida)
        {
            try
            {
                await _productoMethods.ModificarComida(idComida, nombre, descripcion, precio, idCategoriaComida);
                return Ok("Comida modificada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Producto
        [HttpPut("ModificarCombo/{idCombo},{nombre},{descripcion},{descuento},{idCategoriaComida}")]
        public async Task<ActionResult>
            ModificarCombo(int idCombo, string nombre, string descripcion, double descuento, int idCategoria)
        {
            try
            {
                await _productoMethods.ModificarCombo(idCombo, nombre, descripcion, descuento, idCategoria);
                return Ok("Combo modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Producto
        [HttpPut("ModificarCategoriaComida/{idCategoriaComida},{nombre}")]
        public async Task<ActionResult>
            ModificarCategoriaComida(int idCategoriaComida, string nombre)
        {
            try
            {
                await _productoMethods.ModificarCategoriaComida(idCategoriaComida, nombre);
                return Ok("Categoria comida modificada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Producto
        [HttpPut("ModificarCategoriaCombo/{idCategoriaCombo},{nombre}")]
        public async Task<ActionResult>
            ModificarCategoriaCombo(int idCategoriaCombo, string nombre)
        {
            try
            {
                await _productoMethods.ModificarCategoriaCombo(idCategoriaCombo, nombre);
                return Ok("Categoria combo modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Producto
        [HttpPut("ModificarEstadoComida/{idComida},{idEstado}")]
        public async Task<ActionResult>
            ModificarEstadoComida(int idComida, int idEstado)
        {
            try
            {
                await _productoMethods.ModificarEstadoComida(idComida, idEstado);
                return Ok("Estado de la comida modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Producto
        [HttpPut("ModificarEstadoCombo/{idCombo},{idEstado}")]
        public async Task<ActionResult>
            ModificarEstadoCombo(int idCombo, int idEstado)
        {
            try
            {
                await _productoMethods.ModificarEstadoCombo(idCombo, idEstado);
                return Ok("Estado del combo modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Producto
        [HttpDelete("EliminarComidaCarrito/{idComida}")]
        public async Task<ActionResult>
            EliminarComida(int idComida)
        {
            try
            {
                await _productoMethods.EliminarComida(idComida);
                return Ok("Comida eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Producto
        [HttpDelete("EliminarComboCarrito/{idCombo}")]
        public async Task<ActionResult>
            EliminarCombo(int idCombo)
        {
            try
            {
                await _productoMethods.EliminarCombo(idCombo);
                return Ok("Combo eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        // DELETE: api/Producto
        [HttpDelete("EliminarCategoriaComida/{idCategoriaComida}")]
        public async Task<ActionResult>
            EliminarCategoriaComida(int idCategoriaComida)
        {
            try
            {
                await _productoMethods.EliminarCategoriaComida(idCategoriaComida);
                return Ok("Categoria comida eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Producto
        [HttpDelete("EliminarCategoriaCombo/{idCategoriaCombo}")]
        public async Task<ActionResult>
            EliminarCategoriaCombo(int idCategoriaCombo)
        {
            try
            {
                await _productoMethods.EliminarCategoriaCombo(idCategoriaCombo);
                return Ok("Categoria combo eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
