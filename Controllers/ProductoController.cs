using api_restaurante_hamburguesas.Models.Productos;
using api_restaurante_hamburguesas.Models.Productos.Catalogos;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet("ObtenerComidas")]
        public async Task<ActionResult<Comida[]>> 
            ObtenerComidas()
        {
            try
            {
                return await _context.Comidas.ToArrayAsync();
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
                return await _context.Combos.ToArrayAsync();
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
                return await _context.CategoriasComida.ToArrayAsync();
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
                return await _context.CategoriasCombo.ToArrayAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("ObtenerComida/{idComida}")]
        public async Task<ActionResult<Comida>>
            ObtenerComida(int idComida)
        {
            try
            {
                Comida? comida = await _context.Comidas.FindAsync(idComida);
                if (comida == null) throw new Exception("Comida no encontrada");
                return comida;
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
                Combo? combo = await _context.Combos.FindAsync(idCombo);
                if (combo == null) throw new Exception("Combo no encontrado");
                return combo;
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
                CategoriaComida? categoriaComida = await _context.CategoriasComida.FindAsync(idCategoriaComida);
                if (categoriaComida == null) throw new Exception("Categoria comida no encontrada");
                return categoriaComida;
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
                CategoriaCombo? categoriaCombo = await _context.CategoriasCombo.FindAsync(idCategoriaCombo);
                if (categoriaCombo == null) throw new Exception("Categoria combo no encontrado");
                return categoriaCombo;
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
                Combo? combo = await _context.Combos.FindAsync(idCombo);
                if (combo == null) throw new Exception("Combo no encontrado");
                ComboComida[] comboComidas = await _context.ComboComida
                    .Where(b => b.IdCombo == idCombo)
                    .ToArrayAsync();
                if (comboComidas.Length <= 0)
                    throw new Exception($"No se encontraron comidas asociadas al combo {combo.Nombre}");
                return comboComidas.ToArray();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("FiltrarComidas/{idCategoria}")]
        public async Task<ActionResult<Comida[]>>
            FiltrarComidas(int idCategoria)
        {
            try
            {
                return await _context.Comidas
                    .Where(e => e.CategoriaIdComida == idCategoria)
                    .ToArrayAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Producto
        [HttpGet("FiltrarCombos/{idCategoria}")]
        public async Task<ActionResult<Combo[]>>
            FiltrarCombos(int idCategoria)
        {
            try
            {
                return await _context.Combos
                    .Where(e => e.CategoriaIdCombo == idCategoria)
                    .ToArrayAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Producto
        [HttpPost("AgregarComida/{nombre},{descripcion},{precio},{idCategoria}")]
        public async Task<ActionResult>
            AgregarComida(string nombre, string descripcion, double precio, int idCategoria)
        {
            try
            {
                if (precio < 0) { throw new Exception("Formato del precio incorrecto"); }
                Comida comida = new Comida
                {
                    Nombre = nombre,
                    EstadoComidaId = 1,
                    Descripcion = descripcion,
                    Precio = precio,
                    CategoriaIdComida = idCategoria
                };
                await _context.Comidas.AddAsync(comida);
                await _context.SaveChangesAsync();
                return Ok("Comida agregada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Producto
        [HttpPost("AgregarCombo/{nombre},{descripcion},{descuento},{idCategoria}")]
        public async Task<ActionResult>
            AgregarCombo(string nombre, string descripcion, double descuento, int idCategoria)
        {
            try
            {
                if (descuento < 0 || descuento > 1) { throw new Exception("Formato del descuento incorrecto"); }
                Combo combo = new Combo
                {
                    Nombre = nombre,
                    EstadoComboId = 1,
                    Descripcion = descripcion,
                    Descuento = descuento,
                    CategoriaIdCombo = idCategoria
                };
                await _context.Combos.AddAsync(combo);
                await _context.SaveChangesAsync();
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
                if (cantidad < 0) { throw new Exception("Formato de la cantidad incorrecto"); }
                ComboComida comboComida = new ComboComida()
                {
                    IdCombo = idCombo,
                    IdComida = idComida,
                    Cantidad = cantidad
                };
                await _context.ComboComida.AddAsync(comboComida);
                await _context.SaveChangesAsync();
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
                CategoriaComida categoriaComida = new CategoriaComida { Nombre = nombre };
                await _context.CategoriasComida.AddAsync(categoriaComida);
                await _context.SaveChangesAsync();
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
                CategoriaCombo categoriaCombo = new CategoriaCombo { Nombre = nombre };
                await _context.CategoriasCombo.AddAsync(categoriaCombo);
                await _context.SaveChangesAsync();
                return Ok($"La categoria combo ha sido agregada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        // PUT: api/Producto
        [HttpPut("ModificarComida/{idComida},{nombre},{descripcion},{precio},{idCategoria}")]
        public async Task<ActionResult>
            ModificarComida(int idComida, string nombre, string descripcion, double precio, int idCategoria)
        {
            try
            {
                if (precio < 0) { throw new Exception("Formato del precio incorrecto"); }
                // Buscar Comida
                Comida? comida = await _context.Comidas.FindAsync(idComida);
                if (comida == null) { throw new Exception("Comida no encontrada"); }
                comida.Nombre = nombre;
                comida.Descripcion = descripcion;
                comida.Precio = precio;
                comida.CategoriaIdComida = idCategoria;
                await _context.SaveChangesAsync();
                return Ok("Comida modificada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Producto
        [HttpPut("ModificarCombo/{idCombo},{nombre},{descripcion},{descuento},{idCategoria}")]
        public async Task<ActionResult>
            ModificarCombo(int idCombo, string nombre, string descripcion, double descuento, int idCategoria)
        {
            try
            {
                if (descuento < 0 || descuento > 1) { throw new Exception("Formato del descuento incorrecto"); }
                // Buscar Combo
                Combo? combo = await _context.Combos.FindAsync(idCombo);
                if (combo == null) { throw new Exception("Combo no encontrado"); }
                combo.Nombre = nombre;
                combo.Descripcion = descripcion;
                combo.Descuento = descuento;
                combo.CategoriaIdCombo = idCategoria;
                await _context.SaveChangesAsync();
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
                // Buscar Categoria Comida
                CategoriaComida? categoriaComida = await _context.CategoriasComida.FindAsync(idCategoriaComida);
                if (categoriaComida == null) { throw new Exception("Categoria comida no encontrado"); }
                categoriaComida.Nombre = nombre;
                await _context.SaveChangesAsync();
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
                // Buscar Categoria Comida
                CategoriaCombo? categoriaCombo = await _context.CategoriasCombo.FindAsync(idCategoriaCombo);
                if (categoriaCombo == null) { throw new Exception("Categoria combo no encontrado"); }
                categoriaCombo.Nombre = nombre;
                await _context.SaveChangesAsync();
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
                // Buscar Comida
                Comida? comida = await _context.Comidas.FindAsync(idComida);
                if (comida == null) { throw new Exception("Comida no encontrada"); }
                comida.EstadoComidaId = idEstado;
                await _context.SaveChangesAsync();
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
                // Buscar Combo
                Combo? combo = await _context.Combos.FindAsync(idCombo);
                if (combo == null) { throw new Exception("Combo no encontrada"); }
                combo.EstadoComboId = idEstado;
                await _context.SaveChangesAsync();
                return Ok("Estado del combo modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Producto
        [HttpDelete("EliminarComida/{idComida}")]
        public async Task<ActionResult>
            EliminarComida(int idComida)
        {
            try
            {
                Comida? comida = await _context.Comidas.FindAsync(idComida);
                if (comida == null) { throw new Exception("Comida no encontrada"); }
                _context.Comidas.Remove(comida);
                await _context.SaveChangesAsync();
                return Ok("Comida eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Producto
        [HttpDelete("EliminarCombo/{idCombo}")]
        public async Task<ActionResult>
            EliminarCombo(int idCombo)
        {
            try
            {
                Combo? combo = await _context.Combos.FindAsync(idCombo);
                if (combo == null) { throw new Exception("Combo no encontrado"); }
                _context.Combos.Remove(combo);
                await _context.SaveChangesAsync();
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
                CategoriaComida? categoriaComida = await _context.CategoriasComida.FindAsync(idCategoriaComida);
                if (categoriaComida == null) { throw new Exception("Categoria comida no encontrada"); }
                _context.CategoriasComida.Remove(categoriaComida);
                await _context.SaveChangesAsync();
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
                CategoriaCombo? categoriaCombo = await _context.CategoriasCombo.FindAsync(idCategoriaCombo);
                if (categoriaCombo == null) { throw new Exception("Categoria combo no encontrao"); }
                _context.CategoriasCombo.Remove(categoriaCombo);
                await _context.SaveChangesAsync();
                return Ok("Categoria combo eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
