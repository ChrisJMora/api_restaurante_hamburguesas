using api_restaurante_hamburguesas.Models.Orden;
using api_restaurante_hamburguesas.Models.Productos;
using api_restaurante_hamburguesas.Models.Productos.Catalogos;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace api_restaurante_hamburguesas.Auxiliaries.ApiMethods
{
    public class ProductoMethods : Controller
    {
        private readonly ApplicationContext _context;
        private readonly OrdenMethods _ordenMethods;

        public ProductoMethods(ApplicationContext context)
        {
            _context = context;
            _ordenMethods = new OrdenMethods(_context);
        }

        public async Task<Comida[]> 
            ObtenerComidas()
        {
            return await _context.Comidas.ToArrayAsync();
        }

        public async Task<Combo[]> 
            ObtenerCombos()
        {
            return await _context.Combos.ToArrayAsync();
        }

        public async Task<CategoriaComida[]>
            ObtenerCategoriasComida()
        {
            return await _context.CategoriasComida.ToArrayAsync();
        }

        public async Task<CategoriaCombo[]>
            ObtenerCategoriasCombo()
        {
            return await _context.CategoriasCombo.ToArrayAsync();
        }

        public async Task<Comida>
            ObtenerComida(int idComida)
        {
            Comida? comida = await _context.Comidas.FindAsync(idComida);
            if (comida == null) throw new Exception("Comida no encontrada");
            return comida;
        }

        public async Task<Combo>
            ObtenerCombo(int idCombo)
        {
            Combo? combo = await _context.Combos.FindAsync(idCombo);
            if (combo == null) throw new Exception("Combo no encontrado");
            return combo;
        }

        public async Task<CategoriaComida>
            ObtenerCategoriaComida(int idCategoriaComida)
        {
            CategoriaComida? categoriaComida = await _context.CategoriasComida.FindAsync(idCategoriaComida);
            if (categoriaComida == null) throw new Exception("Categoria comida no encontrada");
            return categoriaComida;
        }

        public async Task<CategoriaCombo>
            ObtenerCategoriaCombo(int idCategoriaCombo)
        {
            CategoriaCombo? categoriaCombo = await _context.CategoriasCombo.FindAsync(idCategoriaCombo);
            if (categoriaCombo == null) throw new Exception("Categoria combo no encontrado");
            return categoriaCombo;
        }

        public async Task<ComboComida[]>
            ObtenerComidasCombo(int idCombo)
        {
            ComboComida[] comboComidas = await _context.ComboComida
                .Where(b => b.IdCombo == idCombo)
                .ToArrayAsync();
            if (comboComidas.Length <= 0)
                throw new Exception($"""
                    No se encontraron comidas asociadas al combo con id: {idCombo}
                    """);
            return comboComidas.ToArray();
        }

        public async Task<ComboComida>
            ObtenerComidaCombo(int idCombo, int idComida)
        {
            ComboComida? comboComida = await _context.ComboComida
                .Where(b => b.IdCombo == idCombo)
                .Where(b => b.IdComida == idComida)
                .FirstOrDefaultAsync();
            if (comboComida == null)
                throw new Exception($"""
                    No se encontró una comida asociada al combo con id: {idCombo}
                    y a la comida con id: {idComida}
                    """);
            return comboComida;
        }

        public async Task<Comida[]>
            FiltrarComidas(int idCategoria)
        {
            return await _context.Comidas
                    .Where(e => e.CategoriaIdComida == idCategoria)
                    .ToArrayAsync();
        }

        public async Task<Combo[]>
            FiltrarCombos(int idCategoria)
        {
            return await _context.Combos
                    .Where(e => e.CategoriaIdCombo == idCategoria)
                    .ToArrayAsync();
        }

        public async Task
            AgregarComida(string nombre, string descripcion, double precio, int idCategoria)
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
        }

        public async Task
            AgregarCombo(string nombre, string descripcion, double descuento, int idCategoria)
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
        }

        public async Task
            AgregarComidaCombo(int idCombo, int idComida, int cantidad)
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
        }

        public async Task
            AgregarCategoriaComida(string nombre)
        {
            CategoriaComida categoriaComida = new CategoriaComida { Nombre = nombre };
            await _context.CategoriasComida.AddAsync(categoriaComida);
            await _context.SaveChangesAsync();
        }

        public async Task
            AgregarCategoriaCombo(string nombre)
        {
            CategoriaCombo categoriaCombo = new CategoriaCombo { Nombre = nombre };
            await _context.CategoriasCombo.AddAsync(categoriaCombo);
            await _context.SaveChangesAsync();
        }

        public async Task
            ModificarComida(int idComida, string nombre, string descripcion, double precio, int idCategoria)
        {
            if (precio < 0) { throw new Exception("Formato del precio incorrecto"); }
            Comida comida = await ObtenerComida(idComida);
            comida.Nombre = nombre;
            comida.Descripcion = descripcion;
            comida.Precio = precio;
            comida.CategoriaIdComida = idCategoria;
            await _context.SaveChangesAsync();
        }

        public async Task
            ModificarCombo(int idCombo, string nombre, string descripcion, double descuento, int idCategoria)
        {
            if (descuento < 0 || descuento > 1) { throw new Exception("Formato del descuento incorrecto"); }
            Combo combo = await ObtenerCombo(idCombo);
            combo.Nombre = nombre;
            combo.Descripcion = descripcion;
            combo.Descuento = descuento;
            combo.CategoriaIdCombo = idCategoria;
            await _context.SaveChangesAsync();
        }

        public async Task
            ModificarCategoriaComida(int idCategoriaComida, string nombre)
        {
            CategoriaComida categoriaComida = await ObtenerCategoriaComida(idCategoriaComida);
            categoriaComida.Nombre = nombre;
            await _context.SaveChangesAsync();
        }

        public async Task
            ModificarCategoriaCombo(int idCategoriaCombo, string nombre)
        {
            CategoriaCombo categoriaCombo = await ObtenerCategoriaCombo(idCategoriaCombo);
            categoriaCombo.Nombre = nombre;
            await _context.SaveChangesAsync();
        }

        public async Task
            ModificarEstadoComida(int idComida, int idEstado)
        {
            Comida comida = await ObtenerComida(idComida);
            comida.EstadoComidaId = idEstado;
            await _context.SaveChangesAsync();
        }

        public async Task
            ModificarEstadoCombo(int idCombo, int idEstado)
        {
            Combo combo = await ObtenerCombo(idCombo);
            combo.EstadoComboId = idEstado;
            await _context.SaveChangesAsync();
        }

        public async Task
            EliminarComida(int idComida)
        {
            if (!await ComidaEliminable(idComida))
                throw new Exception("La comida no se puede eliminar");
            Comida comida = await ObtenerComida(idComida);
            _context.Comidas.Remove(comida);
            await _context.SaveChangesAsync();
        }

        public async Task
            EliminarCombo(int idCombo)
        {
            if (!await ComboEliminable(idCombo))
                throw new Exception("El combo no se puede eliminar");
            Combo combo = await ObtenerCombo(idCombo);
            _context.Combos.Remove(combo);
            await _context.SaveChangesAsync();
        }

        public async Task
            EliminarCategoriaComida(int idCategoriaComida)
        {
            CategoriaComida categoriaComida = await ObtenerCategoriaComida(idCategoriaComida);
            _context.CategoriasComida.Remove(categoriaComida);
            await _context.SaveChangesAsync();
        }

        public async Task
            EliminarCategoriaCombo(int idCategoriaCombo)
        {
            CategoriaCombo? categoriaCombo = await ObtenerCategoriaCombo(idCategoriaCombo);
            _context.CategoriasCombo.Remove(categoriaCombo);
            await _context.SaveChangesAsync();
        }

        private async Task<bool>
            ComboEliminable(int idCombo)
        {
            ComboCarrito? comboCarrito = await _context.Carrito
                .Cast<ComboCarrito>()
                .Where(b => b.ComboId == idCombo)
                .FirstOrDefaultAsync();
            return comboCarrito == null;
        }

        private async Task<bool>
            ComidaEliminable(int idComida)
        {
            ComidaCarrito? comidaCarrito = await _context.Carrito
                .Cast<ComidaCarrito>()
                .Where(b => b.ComidaId == idComida)
                .FirstOrDefaultAsync();
            return comidaCarrito == null;
        }
    }
}
