using api_restaurante_hamburguesas.Models.Productos.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Productos.Catalogos
{
    public class ListaCategoriasCombo
    {
        public List<CategoriaCombo> categoriasCombo = new List<CategoriaCombo>()
        {
            new CategoriaCombo() { CategoriaIdCombo = 1, Nombre = "ComboCarrito Familiar"},
            new CategoriaCombo() { CategoriaIdCombo = 2, Nombre = "ComboCarrito Individual"},
            new CategoriaCombo() { CategoriaIdCombo = 3, Nombre = "ComboCarrito Infantil"}
        };
    }
}
