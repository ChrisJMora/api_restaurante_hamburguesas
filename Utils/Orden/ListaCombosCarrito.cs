using api_restaurante_hamburguesas.Models.Orden;

namespace api_restaurante_hamburguesas.Utils.Orden
{
    public class ListaCombosCarrito
    {
        public List<ComboCarrito> listaCombosCarrito = new List<ComboCarrito>()
        {
            // COMBO 1: Combo Clásico | ORDEN: 1
            new ComboCarrito()
            {
                ProductoCarritoId = 1,  // PrimaryKey
                OrdenId = 1,            // Orden: 1   
                ComboId = 1,            // Combo: Combo Clásico
                Cantidad = 3,           // Cantidad: 3
            },

            // COMBO 2: Combo Clásico | ORDEN: 1
            new ComboCarrito()
            {
                ProductoCarritoId = 2,  // PrimaryKey
                OrdenId = 1,            // Orden: 1   
                ComboId = 1,            // Combo: Combo Clásico
                Cantidad = 2,           // Cantidad: 3
            },

            // COMBO 3: Combo Mini Burguer | ORDEN: 2
            new ComboCarrito()
            {
                ProductoCarritoId = 3,  // PrimaryKey
                OrdenId = 2,            // Orden: 2   
                ComboId = 3,            // Combo: Combo Mini Burguer
                Cantidad = 1,           // Cantidad: 1
            },

        };
    }
}
