using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_restauranteHamburguesas.Data;
using api_restaurante_hamburguesas.Models.Orden;
using api_restaurante_hamburguesas.Models.Productos;

namespace api_restaurante_hamburguesas.Auxiliaries.ApiMethods
{
    public class CarritoMethods : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ProductoMethods _productoMethods;

        public CarritoMethods(ApplicationContext context)
        {
            _context = context;
            _productoMethods = new ProductoMethods(_context);
        }
        
        public async Task<ProductoCarrito> 
            ObtenerProducto(int idProducto)
        {
            ProductoCarrito? producto = await _context.Carrito.FindAsync(idProducto);
            if (producto == null) throw new Exception("Producto no encontrado");
            return producto;
        }

        public bool
            OrdenRgistrada(int idOrden)
        {
            ProductoCarrito[] productos =
                _context.Carrito
                .Where(b => b.IdOrden == idOrden)
                .ToArray();
            return productos.Length > 0;
        }

        public async Task<ComidaCarrito>
            ObtenerComidaCarrito(int idComidaCarrito)
        {
            ProductoCarrito? productoCarrito = await _context.Carrito
                    .FindAsync(idComidaCarrito);
            if (productoCarrito == null) throw new Exception("Producto carrito no encontrado");
            if (productoCarrito is ComboCarrito) throw new Exception($"El producto con id: {idComidaCarrito} es un combo");
            return (ComidaCarrito)productoCarrito;
        }

        public async Task<ComboCarrito>
            ObtenerComboCarrito(int idComboCarrito)
        {
            ProductoCarrito? productoCarrito = await _context.Carrito
                    .FindAsync(idComboCarrito);
            if (productoCarrito == null) throw new Exception("Producto carrito no encontrado");
            if (productoCarrito is ComidaCarrito) throw new Exception($"El producto con id: {idComboCarrito} es una comida");
            return (ComboCarrito)productoCarrito;
        }

        public async Task<ComidaCarrito[]>
            ObtenerComidas(int idOrden)
        {
            ComidaCarrito[] comidas = await _context.Carrito
                    .Where(b => b.IdOrden == idOrden)
                    .Where(b => b is ComidaCarrito)
                    .Cast<ComidaCarrito>()
                    .Where(b => b.IdComboCarrito == null)
                    .ToArrayAsync();
            return comidas;
        }

        public async Task<ComidaCarrito?>
            ObtenerComidaCarrito(int idOrden, int idComida)
        {
            ComidaCarrito? comida =
                await _context.Carrito
                .Where(b => b.IdOrden == idOrden)
                .Where(b => b is ComidaCarrito)
                .Cast<ComidaCarrito>()
                .Where(b => b.IdComida == idComida)
                .FirstOrDefaultAsync();
            return comida;
        }

        public async Task<ComboCarrito[]>
            ObtenerCombos(int idOrden)
        {
            ComboCarrito[] combos = await _context.Carrito
                    .Where(b => b.IdOrden == idOrden)
                    .Where(b => b is ComboCarrito)
                    .Cast<ComboCarrito>()
                    .ToArrayAsync();
            return combos;
        }

        public async Task<ComidaCarrito[]>
            ObtenerComidasCombo(int idComboCarrito)
        {
            ComidaCarrito[] comidas = await _context.Carrito
                    .Where(b => b is ComidaCarrito)
                    .Cast<ComidaCarrito>()
                    .Where(b => b.IdComboCarrito == idComboCarrito)
                    .ToArrayAsync();
            return comidas;
        }

        public async Task<double>
            CalcularTotalCombo(int idComboCarrito)
        {
            ComboCarrito comboCarrito = await ObtenerComboCarrito(idComboCarrito);
            Combo combo = await _productoMethods.ObtenerCombo(comboCarrito.IdCombo);
            ComidaCarrito[] comidas = await ObtenerComidasCombo(idComboCarrito);
            double total = 0;
            foreach (var comidaCarrito in comidas)
            {
                Comida comida = await _productoMethods.ObtenerComida(comidaCarrito.IdComida);
                total += comida.Precio * comidaCarrito.Cantidad;
            }
            return total;
        }

        public async Task<double>
            CalcularTotalComidas(int idOrden)
        {
            double total = 0;
            ComidaCarrito[] comidasCarrito = await ObtenerComidas(idOrden);
            foreach (var comidaCarrito in comidasCarrito)
            {
                Comida comida = await _productoMethods.ObtenerComida(comidaCarrito.IdComida);
                total += comida.Precio * comidaCarrito.Cantidad;
            }
            return total;
        }

        public async Task
            ModificarCantidad(int idProducto, int cantidad)
        {
            if (cantidad <= 0) throw new Exception("La cantidad debe ser mayor a cero");
            ProductoCarrito producto = await ObtenerProducto(idProducto);
            producto.Cantidad += cantidad;
            await _context.SaveChangesAsync();
        }

        public async Task
            AgregarComidaCarrito(int idOrden, int idComida, int cantidad)
        {
            ComidaCarrito nuevaComida = new ComidaCarrito()
            {
                IdOrden = idOrden,
                IdComida = idComida,
                Cantidad = cantidad,
            };
            // COMIDA REPETIDA?
            ComidaCarrito? comida = await ObtenerComidaCarrito(idOrden, idComida);
            if (comida != null)
            {
                await ModificarCantidad(comida.IdComida, cantidad);
            }
            else
            {
                // AGREGAR NUEVA COMIDA
                await AgregarProducto(nuevaComida);
                await _context.SaveChangesAsync();
            }

        }

        private async Task<int>
            ComboRepetido(int idOrden, int idCombo, ComidaCarrito[] nuevasComidasCarrito)
        {
            ComboCarrito? combo =
                await _context.Carrito
                .Where(b => b.IdOrden == idOrden)
                .Where(b => b is ComboCarrito)
                .Cast<ComboCarrito>()
                .Where(b => b.IdCombo == idCombo)
                .FirstOrDefaultAsync();
            if (combo == null) 
                return -1;
            ComidaCarrito[] comidasCarrito = await ObtenerComidasCombo(combo.IdCombo);
            if (!comidasCarrito.SequenceEqual(nuevasComidasCarrito)) 
                return -1;
            return combo.IdCombo;
        }

        public async Task
            AgregarComboCarrito(int idOrden, int idCombo, int cantidad, int[] idComidas)
        {
            ComboCarrito nuevoCombo = new ComboCarrito()
            {
                IdOrden = idOrden,
                IdCombo = idCombo,
                Cantidad = cantidad,
            };

            List<ComidaCarrito> comidas = new List<ComidaCarrito>();

            foreach (var idComida in idComidas)
            {
                ComidaCombo comboComida = await _productoMethods.ObtenerComidaCombo(idCombo, idComida);
                comidas.Add(new ComidaCarrito()
                {
                    ComboCarrito = nuevoCombo,
                    IdOrden = idOrden,
                    IdComida = idComida,
                    Cantidad = comboComida.Cantidad,
                });
            }
            // COMBO REPETIDO?
            int idComboCarrito = await ComboRepetido(idOrden, idCombo, comidas.ToArray());
            if (idComboCarrito != -1)
            {
                await ModificarCantidad(idComboCarrito, cantidad);
            }
            else
            {
                // AGREGAR COMBO
                await AgregarProducto(nuevoCombo);
                await AgregarProductos(comidas.ToArray());
                await _context.SaveChangesAsync();
            }
        }

        public async Task
            AumentarCantidad(int idProducto)
        {
            await ModificarCantidad(idProducto, 1);
        }

        public async Task
            DisminuirCantidad(int idProducto)
        {
            await ModificarCantidad(idProducto, -1);
        }

        private async Task
            EliminarProducto<T>(T producto) where T : ProductoCarrito
        {
            _context.Carrito.Remove(producto);
            await _context.SaveChangesAsync();
        }

        private async Task
            EliminarProductos<T>(T[] productos) where T : ProductoCarrito
        {
            _context.Carrito.RemoveRange(productos);
            await _context.SaveChangesAsync();
        }

        public async Task
            EliminarCombo(int idProducto)
        {
            ComidaCarrito[] comidas = await ObtenerComidasCombo(idProducto);
            await EliminarProductos<ComidaCarrito>(comidas);
            ComboCarrito combo = await ObtenerComboCarrito(idProducto);
            await EliminarProducto<ComboCarrito>(combo);
        }

        public async Task
            EliminarComida(int idProducto)
        {
            ComidaCarrito? comida = await ObtenerComidaCarrito(idProducto);
            await EliminarProducto<ComidaCarrito>(comida);
        }

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
    }
}
