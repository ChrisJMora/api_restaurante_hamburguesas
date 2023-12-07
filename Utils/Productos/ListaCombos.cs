using api_restaurante_hamburguesas.Models.Productos;

namespace api_restaurante_hamburguesas.Utils.Productos
{
    public class ListaCombos
    {
        public List<Combo> listasCombos = new List<Combo>()
        {
            new Combo
            {
                ProductoId = 1,
                Nombre = "ComboCarrito Clásico",
                EstadoComboId = 1,
                Descripcion = """
                    El combo clásico incluye una hamburguesa con queso,
                    acompañada por papas fritas y una bebida refrescante.
                    """,
                Descuento = 0.3,
                CategoriaIdCombo = 2
            },
            new Combo
            {
                ProductoId = 2,
                Nombre = "ComboCarrito Para Todos",
                EstadoComboId = 1,
                Descripcion = """
                    El Combo "Para Todos" ofrece hamburguesas individuales
                    variadas con nachos cubiertos de sabores intensos,
                    papas fritas especiales y una jarra grande de bebidas refrescantes.
                    ¡Ideal para satisfacer los gustos de todos en el grupo!
                    """,
                Descuento = 0.2,
                CategoriaIdCombo = 1
            },
            new Combo
            {
                ProductoId = 3,
                Nombre = "ComboCarrito Mini Burguer",
                EstadoComboId = 1,
                Descripcion = """
                    El Combo "Mini Burguer" ofrece una hamburguesa pequeña
                    con queso y vegetales, acompañada de papas fritas y
                    una bebida refrescante, perfecto para los más pequeños.
                    """,
                Descuento = 0.1,
                CategoriaIdCombo = 3
            }
        };
    }
}
