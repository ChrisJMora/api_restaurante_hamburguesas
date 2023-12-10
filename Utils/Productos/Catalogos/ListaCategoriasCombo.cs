using api_restaurante_hamburguesas.Models.Productos.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Productos.Catalogos
{
    public class ListaCategoriasCombo
    {
        public List<CategoriaCombo> categoriasCombo = new List<CategoriaCombo>()
        {
            new CategoriaCombo() { Id = 1, Etiqueta = "ComboCarrito Familiar"},
            new CategoriaCombo() { Id = 2, Etiqueta = "ComboCarrito Individual"},
            new CategoriaCombo() { Id = 3, Etiqueta = "ComboCarrito Infantil"}
        };
    }
}
