using api_restaurante_hamburguesas.Models.Productos.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Productos.Catalogos
{
    public class ListaCategoriasComida
    {
        public List<CategoriaComida> categoriasComida = new List<CategoriaComida>()
        {
            new CategoriaComida{Id = 1, Etiqueta = "Hamburguesa"},
            new CategoriaComida{Id = 2, Etiqueta = "Bebida"},
            new CategoriaComida{Id = 3, Etiqueta = "Complemento"},
            new CategoriaComida{Id = 4, Etiqueta = "Postre"}
        };
    }
}
