using api_restaurante_hamburguesas.Models.Productos.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Productos.Catalogos
{
    public class ListaCategoriasComida
    {
        public List<CategoriaComida> categoriasComida = new List<CategoriaComida>()
        {
            new CategoriaComida{CategoriaId_Comida = 1, Nombre = "Hamburguesa"},
            new CategoriaComida{CategoriaId_Comida = 2, Nombre = "Bebida"},
            new CategoriaComida{CategoriaId_Comida = 3, Nombre = "Complemento"},
            new CategoriaComida{CategoriaId_Comida = 4, Nombre = "Postre"}
        };
    }
}
