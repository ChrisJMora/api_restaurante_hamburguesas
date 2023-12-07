using api_restaurante_hamburguesas.Models.Productos.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Productos.Catalogos
{
    public class ListaCategoriasComida
    {
        public List<CategoriaComida> categoriasComida = new List<CategoriaComida>()
        {
            new CategoriaComida{CategoriaIdComida = 1, Nombre = "Hamburguesa"},
            new CategoriaComida{CategoriaIdComida = 2, Nombre = "Bebida"},
            new CategoriaComida{CategoriaIdComida = 3, Nombre = "Complemento"},
            new CategoriaComida{CategoriaIdComida = 4, Nombre = "Postre"}
        };
    }
}
