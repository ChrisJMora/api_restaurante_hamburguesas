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
                Id = 1,  // PrimaryKey
                IdOrden = 1,            // Orden: 1   
                IdCombo = 1,            // Combo: Combo Clásico
                Cantidad = 3,           // Cantidad: 3
            },

            // COMBO 2: Combo Clásico | ORDEN: 1
            new ComboCarrito()
            {
                Id = 2,  // PrimaryKey
                IdOrden = 1,            // Orden: 1   
                IdCombo = 1,            // Combo: Combo Clásico
                Cantidad = 2,           // Cantidad: 3
            },

            // COMBO 3: Combo Mini Burguer | ORDEN: 2
            new ComboCarrito()
            {
                Id = 3,  // PrimaryKey
                IdOrden = 2,            // Orden: 2   
                IdCombo = 3,            // Combo: Combo Mini Burguer
                Cantidad = 1,           // Cantidad: 1
            },

        };
    }
}
