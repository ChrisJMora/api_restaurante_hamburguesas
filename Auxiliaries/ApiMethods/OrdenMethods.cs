using api_restaurante_hamburguesas.Auxiliaries;
using api_restaurante_hamburguesas.Models.Orden;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_restaurante_hamburguesas.Auxiliaries.ApiMethods
{
    public class OrdenMethods : Controller
    {
        private readonly ApplicationContext _context;
        private readonly CarritoMethods _carritoMethods;

        public OrdenMethods(ApplicationContext context)
        {
            _context = context;
            _carritoMethods = new CarritoMethods(context);
        }

        public async Task<Orden>
            ObtenerOrden(int idOrden)
        {
            Orden? orden = await _context.Ordenes.FindAsync(idOrden);
            if (orden == null) throw new Exception("Orden no encontrada");
            return orden;
        }

        public async Task<int>
            ObtenerNuevaOrden(int idCliente)
        {
            Orden[] ordenesCliente = await ObtenerOrdenesCliente(idCliente);

            foreach (var orden in ordenesCliente)
            {
                if (!_carritoMethods.OrdenRgistrada(orden.Id))
                {
                    return orden.Id;
                }
            }
            throw new Exception("No se encontró una nueva orden");
        }

        public async Task<Orden[]>
            ObtenerOrdenes()
        {
            Orden[] ordenes = await _context.Ordenes.ToArrayAsync();
            if (ordenes.Length == 0) throw new Exception("No hay ordenes disponibles");
            return ordenes;
        }

        public async Task<Orden[]>
            ObtenerOrdenesCliente(int idCliente)
        {
            Orden[] ordenes = await _context.Ordenes
                .Where(b => b.IdCliente == idCliente)
                .ToArrayAsync();
            if (ordenes.Length == 0) throw new Exception($"No hay ordenes asociadas al cliente con id: {idCliente}");
            return ordenes;
        }

        public async Task
            CrearOrden(int idCliente)
        {
            Orden orden = new Orden()
            {
                IdCliente = idCliente,
                Fecha = new FechaHora().ObtenerFechaHoraLocal()
            };
            await _context.Ordenes.AddAsync(orden);
            await _context.SaveChangesAsync();
        }
    }
}
