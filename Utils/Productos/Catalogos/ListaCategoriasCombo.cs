using api_restaurante_hamburguesas.Models.Productos.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Productos.Catalogos
{
    public class ListaCategoriasCombo
    {
        public List<CategoriaCombo> categoriasCombo = new List<CategoriaCombo>()
        {
            new CategoriaCombo() { CategoriaId_Combo = 1, Nombre = "ComboCarrito Familiar"},
            new CategoriaCombo() { CategoriaId_Combo = 2, Nombre = "ComboCarrito Individual"},
            new CategoriaCombo() { CategoriaId_Combo = 3, Nombre = "ComboCarrito Infantil"}
        };
    }
}
