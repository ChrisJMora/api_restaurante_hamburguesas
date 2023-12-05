using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_restauranteHamburguesas.Data;
using api_restaurante_hamburguesas.Models.Orden;
using api_restaurante_hamburguesas.Models.Productos;

namespace api_restaurante_hamburguesas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CarritoController(ApplicationContext context)
        {
            _context = context;
        }
        
        // GET: api/Carrito
        [HttpGet("ObtenerProducto/{idProducto}")]
        public async Task<ActionResult<ProductoCarrito>> 
            ObtenerProducto(int idProducto)
        {
            try { return Ok(await BuscarProducto<ProductoCarrito>(idProducto)); }
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
                ProductoCarrito[] comidas = await _context.Carrito
                    .Where(b => b.OrdenId == idOrden)
                    .Where(b => b is ComidaCarrito)
                    .Cast<ComidaCarrito>()
                    .Where(b => b.ComboCarritoId == null)
                    .ToArrayAsync();
                return Ok(comidas);
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
                ProductoCarrito[] combos = await _context.Carrito
                    .Where(b => b.OrdenId == idOrden)
                    .Where(b => b is ComboCarrito)
                    .Cast<ComboCarrito>()
                    .ToArrayAsync();
                return Ok(combos); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Carrito
        [HttpGet("ObtenerComidasCombo/{idCombo}")]
        public async Task<ActionResult<ComboCarrito[]>>
            ObtenerComidasCombo(int idCombo)
        {
            try
            {
                ProductoCarrito[] comidas = await _context.Carrito
                    .Where(b => b is ComidaCarrito)
                    .Cast<ComidaCarrito>()
                    .Where(b => b.ComboCarritoId == idCombo )
                    .ToArrayAsync();
                return Ok(comidas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Carrito/5
        [HttpPost("AgregarComboCarrito/{idOrden},{idCombo},{cantidad}")]
        public async Task<ActionResult>
            AgregarComboCarrito(int idOrden, int idCombo, int cantidad, int[] idComidas)
        {
            try { return await AgregarCombo(idOrden, idCombo, cantidad, idComidas); }
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
            try { return await AgregarComida(idOrden, idComida, cantidad); }
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
            try { return Ok(await ModificarCantidad(idProducto, cantidad)); }
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
            try { return Ok(await AumentarCantidad(idProducto)); }
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
            try { return Ok(await DisminuirCantidad(idProducto)); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Carrito/5
        [HttpDelete("EliminarCombo/{idProducto}")]
        public async Task<ActionResult>
            EliminarCombo(int idProducto)
        {
            try
            {
                ComidaCarrito[] comidas = await BuscarComidasByCombo(idProducto);
                await EliminarProductos<ComidaCarrito>(comidas);
                ComboCarrito combo = await BuscarProducto<ComboCarrito>(idProducto);
                await EliminarProducto<ComboCarrito>(combo);
                return Ok(combo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Carrito/5
        [HttpDelete("EliminarComida/{idProducto}")]
        public async Task<ActionResult>
            EliminarComida(int idProducto)
        {
            try
            {
                ComidaCarrito comida = await BuscarProducto<ComidaCarrito>(idProducto);
                await EliminarProducto<ComidaCarrito>(comida);
                return Ok(comida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // CREATE

            // PRODUCTO

        private async Task
            AgregarProductos<T>(T[] productos) where T : ProductoCarrito
        {
            await _context.Carrito.AddRangeAsync(productos);
        }

        private async Task
            AgregarProducto<T>(T producto) where T : ProductoCarrito
        {
            await _context.Carrito.AddAsync(producto);
        }

            // COMBO

        private async Task<ActionResult>
            AgregarCombo(int idOrden, int idCombo, int cantidad, int[] idComidas)
        {
            ComboCarrito nuevoCombo = new ComboCarrito()
            {
                OrdenId = idOrden,
                ComboId = idCombo,
                Cantidad = cantidad,
            };

            List<ComidaCarrito> comidas = new List<ComidaCarrito>();

            foreach (var idComida in idComidas)
            {
                ComboComida? comboComida =
                    await _context.ComboComida
                    .Where(b => b.IdCombo == idCombo)
                    .Where(b => b.IdComida == idComida)
                    .FirstOrDefaultAsync();
                if (comboComida == null) throw new Exception("No hay relación entre el combo con las comidas dadas");
                comidas.Add(new ComidaCarrito()
                {
                    ComboCarrito = nuevoCombo,
                    OrdenId = idOrden,
                    ComidaId = idComida,
                    Cantidad = comboComida.Cantidad,
                });
            }

            ComboCarrito? combo = await ComboRepetido(nuevoCombo, comidas.ToArray());

            if (combo != null)
            {
                await ModificarCantidad(combo.ProductoCarritoId, cantidad);
                return Ok($"Se aumentaron {cantidad} unidades al combo con ID: {combo.ProductoCarritoId}");
            }

            await AgregarProducto(nuevoCombo);
            await AgregarProductos(comidas.ToArray());

            await GuardarCambios();
            return Ok($"El combo con ID: {nuevoCombo.ProductoCarritoId} fue añadido con éxito");
        }

            // COMIDA

        private async Task<ActionResult>
            AgregarComida(int idOrden, int idComida, int cantidad)
        {
            ComidaCarrito nuevaComida = new ComidaCarrito()
            {
                OrdenId = idOrden,
                ComidaId = idComida,
                Cantidad = cantidad,
            };

            ComidaCarrito? comida = await BuscarComida(idOrden, idComida);

            if (comida != null)
            {
                await ModificarCantidad(comida.ProductoCarritoId, cantidad);
                return Ok($"Se aumentaron {cantidad} unidades a la comida con ID: {comida.ProductoCarritoId}");
            }

            await AgregarProducto(nuevaComida);
            await GuardarCambios();

            return Ok($"La comida con ID: {nuevaComida.ProductoCarritoId} fue añadido con éxito");
        }

        // READ

            // PRODUCTO

        private async Task<T>
            BuscarProducto<T>(int idProducto) where T : ProductoCarrito
        {
            ProductoCarrito? producto = await _context.Carrito.FindAsync(idProducto);
            if (producto == null) throw new Exception("Producto no encontrado");
            return (T)producto;
        }

            // COMBO

        private async Task<Dictionary<int, ComidaCarrito[]>>
            BuscarCombos(int idOrden)
        {
            Dictionary<int, ComidaCarrito[]> diccionario = new Dictionary<int, ComidaCarrito[]>();

            ComboCarrito[] combos =
                await _context.Carrito
                .Where(b => b is ComboCarrito && b.OrdenId == idOrden)
                .Cast<ComboCarrito>()
                .ToArrayAsync();

            if (combos.Length == 0) throw new Exception($"No hay comidas asociados con la orden con ID: {idOrden}");

            for (int i = 0; i < combos.Length; i++)
            {
                ComidaCarrito[] comidas =
                     await _context.Carrito
                    .Where(b => b is ComidaCarrito && ((ComidaCarrito)b).ComboCarritoId == combos[i].ProductoCarritoId)
                    .Cast<ComidaCarrito>()
                    .ToArrayAsync();

                if (comidas.Length == 0) throw new Exception($"No hay comidas asociadas con el combo con ID: {combos[i].ProductoCarritoId}");

                diccionario.Add(combos[i].ProductoCarritoId, comidas);
            }

            return diccionario;
        }

            // COMIDA

        private async Task<ComidaCarrito?>
            BuscarComida(int idOrden, int idComida)
        {
            ComidaCarrito? comida =
                await _context.Carrito
                .Where(b => b.OrdenId == idOrden &&
                ((ComidaCarrito)b).ComboCarritoId == null &&
                ((ComidaCarrito)b).ComidaId == idComida)
                .Cast<ComidaCarrito>()
                .FirstOrDefaultAsync();

            return comida;
        }

        private async Task<ComidaCarrito[]>
            BuscarComidasByOrden(int idOrden)
        {
            ComidaCarrito[] comidas =
                await _context.Carrito
                .Where(b => b is ComidaCarrito &&
                b.OrdenId == idOrden &&
                ((ComidaCarrito)b).ComboCarritoId == null)
                .Cast<ComidaCarrito>()
                .ToArrayAsync();

            if (comidas.Length == 0) throw new Exception($"""
                La orden con ID: {idOrden} no cuenta con comidas sin combo
                """);

            return comidas;
        }

        private async Task<ComidaCarrito[]>
            BuscarComidasByCombo(int idCombo)
        {
            ComidaCarrito[] comidas =
                await _context.Carrito
                .Where(b => ((ComidaCarrito)b).ComboCarritoId == idCombo)
                .Cast<ComidaCarrito>()
                .ToArrayAsync();

            if (comidas.Length == 0) throw new Exception($"""
                No hay comidas asociadas con el combo con ID: {idCombo}
                """);

            return comidas;
        }

        // UPDATE

            //PRODUCTO

        private async Task<ProductoCarrito>
            ModificarCantidad(int idProducto, int cantidad)
        {
            ProductoCarrito producto = await BuscarProducto<ProductoCarrito>(idProducto);
            producto.Cantidad += cantidad;
            await GuardarCambios();
            return producto;
        }

        private async Task<ProductoCarrito>
            AumentarCantidad(int idProducto)
        {
            return await ModificarCantidad(idProducto, 1);
        }

        private async Task<ProductoCarrito>
            DisminuirCantidad(int idProducto)
        {
            return await ModificarCantidad(idProducto, -1);
        }

        // DELETE

            // PRODUCTO

        private async Task<T>
            EliminarProducto<T>(T producto) where T : ProductoCarrito
        {
            _context.Carrito.Remove(producto);
            await GuardarCambios();

            return producto;
        }

        private async Task<T[]>
            EliminarProductos<T>(T[] productos) where T : ProductoCarrito
        {
            _context.Carrito.RemoveRange(productos);
            await GuardarCambios();

            return productos;
        }

        // MÉTODOS ADICIONALES

        private async Task<ComboCarrito?>
            ComboRepetido(ComboCarrito nuevoCombo, ComidaCarrito[] comidas)
        {
            try
            {
                Dictionary<int, ComidaCarrito[]> combos = await BuscarCombos(nuevoCombo.OrdenId);
                foreach (KeyValuePair<int, ComidaCarrito[]> entry in combos)
                {
                    ComboCarrito combo = await BuscarProducto<ComboCarrito>(entry.Key);
                    if (combo.Equals(nuevoCombo) && entry.Value.SequenceEqual(comidas)) 
                        return combo;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task 
            GuardarCambios()
        {
            await _context.SaveChangesAsync();
        }
    }
}
