using api_restaurante_hamburguesas.Models;
using API_restauranteHamburguesas.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_restaurante_hamburguesas.Auxiliaries.ApiMethods
{
    public class EstadoMethods : Controller
    {
        private readonly ApplicationContext _context;

        public EstadoMethods(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Estado[]>
            ObtenerEstados()
        {
            Estado[] estadosUsuario = await _context.Estados.ToArrayAsync();
            if (estadosUsuario.Length == 0) throw new Exception("Lista de estados de usuario vacía");
            return estadosUsuario;
        }

        public async Task<Estado>
            ObtenerEstado(int idEstado)
        {
            Estado? estado = await _context.Estados.FindAsync(idEstado);
            if (estado == null)
                throw new Exception("Estado no encontrado");
            return estado;
        }
    }
}
