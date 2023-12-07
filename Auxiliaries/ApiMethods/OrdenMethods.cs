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

        public OrdenMethods(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Orden>
            ObtenerOrden(int idOrden)
        {
            Orden? orden = await _context.Ordenes.FindAsync(idOrden);
            if (orden == null) throw new Exception("Orden no encontrada");
            return orden;
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
                .Where(b => b.ClienteId == idCliente)
                .ToArrayAsync();
            if (ordenes.Length == 0) throw new Exception($"No hay ordenes asociadas al cliente con id: {idCliente}");
            return ordenes;
        }

        public async Task
            CrearOrden(int idCliente)
        {
            Orden orden = new Orden()
            {
                ClienteId = idCliente,
                Fecha = new FechaHora().ObtenerFechaHoraLocal()
            };
            await _context.Ordenes.AddAsync(orden);
            await _context.SaveChangesAsync();
        }
    }
}
