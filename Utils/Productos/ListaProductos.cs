using api_restaurante_hamburguesas.Models.Productos;
using NuGet.Packaging;

namespace api_restaurante_hamburguesas.Utils.Productos

{
    public class ListaProductos
    {
        public List<Producto> productos = new List<Producto>();

        public ListaProductos()
        {
            productos.AddRange(new ListaComidas().listaComidas);
            productos.AddRange(new ListaCombos().listasCombos);
        }
    }
}
