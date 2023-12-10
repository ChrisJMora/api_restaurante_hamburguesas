using api_restaurante_hamburguesas.Models.Orden;

namespace api_restaurante_hamburguesas.Utils.Orden
{
    public class ListaProductosCarrito
    {
        public List<ProductoCarrito> listaProductosCarrito = new List<ProductoCarrito>()
        {
            // COMBO 1: Combo Clásico | ORDEN: 1
            new ComboCarrito()
            {
                Id = 1,  // PrimaryKey
                IdOrden = 1,            // Orden: 1   
                IdCombo = 1,            // Combo: Combo Clásico
                Cantidad = 3,           // Cantidad: 3
            },
            // COMIDA DEL COMBO 1
            // [Hamburguesa Clásica, Papas Fritas Pequeñas, Coca Cola (500ml), Helado de Vainilla]
            new ComidaCarrito()
            {
                Id = 2,  // PrimaryKey
                IdComboCarrito = 1,     // ForeignKey: ComboCarrito [1]
                IdOrden = 1,            // Orden: 1
                IdComida = 1,           // Comida: Hamburguesa Clásica
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                Id = 3,  // PrimaryKey
                IdComboCarrito = 1,     // ForeignKey: ComboCarrito [1]
                IdOrden = 1,            // Orden: 1
                IdComida = 5,           // Comida: Papas Fritas Pequeñas
                Cantidad = 5,           // Cantidad: 5
            },
            new ComidaCarrito()
            {
                Id = 4,  // PrimaryKey
                IdComboCarrito = 1,     // ForeignKey: ComboCarrito [1]
                IdOrden = 1,            // Orden: 1
                IdComida = 6,           // Comida: Coca Cola (500 ml)
                Cantidad = 5,           // Cantidad: 5
            },
            new ComidaCarrito()
            {
                Id = 5,  // PrimaryKey
                IdComboCarrito = 1,     // ForeignKey: ComboCarrito [1]
                IdOrden = 1,            // Orden: 1
                IdComida = 7,           // Comida: Helado de Vainilla
                Cantidad = 2,           // Cantidad: 2
            },

            // COMBO 2: Combo Clásico | ORDEN: 1
            new ComboCarrito()
            {
                Id = 6,  // PrimaryKey
                IdOrden = 1,            // Orden: 1   
                IdCombo = 1,            // Combo: Combo Clásico
                Cantidad = 2,           // Cantidad: 3
            },
            // COMIDA DEL COMBO 2
            // [Hamburguesa Clásica, Papas Fritas Grandes, Coca Cola (500ml), Helado de Chocolate]
            new ComidaCarrito()
            {
                Id = 8,  // PrimaryKey
                IdComboCarrito = 5,     // ForeignKey: ComboCarrito [5]
                IdOrden = 1,            // Orden: 1
                IdComida = 1,           // Comida: Hamburguesa Clásica
                Cantidad = 2,           // Cantidad: 2
            },
            new ComidaCarrito()
            {
                Id = 9,  // PrimaryKey
                IdComboCarrito = 5,     // ForeignKey: ComboCarrito [5]
                IdOrden = 1,            // Orden: 1
                IdComida = 4,           // Comida: Papas Fritas Grandes
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                Id = 10,  // PrimaryKey
                IdComboCarrito = 5,     // ForeignKey: ComboCarrito [5]
                IdOrden = 1,            // Orden: 1
                IdComida = 6,           // Comida: Coca Cola (500ml)
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                Id = 11,  // PrimaryKey
                IdComboCarrito = 5,     // ForeignKey: ComboCarrito [5]
                IdOrden = 1,            // Orden: 1
                IdComida = 8,           // Comida: Helado de Chocolate
                Cantidad = 1,           // Cantidad: 1
            },

            // COMBO 3: Combo Mini Burguer | ORDEN: 2
            new ComboCarrito()
            {
                Id = 12,  // PrimaryKey
                IdOrden = 2,            // Orden: 2   
                IdCombo = 3,            // Combo: Combo Mini Burguer
                Cantidad = 1,           // Cantidad: 1
            },
            // COMIDA DEL COMBO 3
            // [Mini Hamburguesa Sencilla, Papas Fritas Pequeñas, Coca Cola (500ml), Helado de Vainilla]
            new ComidaCarrito()
            {
                Id = 13,  // PrimaryKey
                IdComboCarrito = 9,     // ForeignKey: ComboCarrito [9]
                IdOrden = 2,            // Orden: 2
                IdComida = 3,           // Comida: Mini Hamburguesa Sencilla
                Cantidad = 1,           // Cantidad: 1
            },
            new ComidaCarrito()
            {
                Id = 14,  // PrimaryKey
                IdComboCarrito = 9,     // ForeignKey: ComboCarrito [9]
                IdOrden = 2,            // Orden: 2
                IdComida = 5,           // Comida: Papas Fritas Pequeñas
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                Id = 15,  // PrimaryKey
                IdComboCarrito = 9,     // ForeignKey: ComboCarrito [9]
                IdOrden = 2,            // Orden: 2
                IdComida = 6,           // Comida: Coca Cola (500ml)
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                Id = 16,  // PrimaryKey
                IdComboCarrito = 9,     // ForeignKey: ComboCarrito [9]
                IdOrden = 2,            // Orden: 2
                IdComida = 7,           // Comida: Helado de Vainilla
                Cantidad = 3,           // Cantidad: 3
            },

            // COMIDA QUE NO FORMA PARTE DE UN COMBO
            // HAMBURGUESA DOBLE | ORDEN: 2
            new ComidaCarrito()
            {
                Id = 17, // PrimaryKey
                IdComboCarrito = null,  // ForeignKey: ComboCarrito [null]
                IdOrden = 2,            // Orden: 2
                IdComida = 2,           // Comida: Hamburguesa Doble
                Cantidad = 4,           // Cantidad: 4
            },
            // COCA COLA (500ml) | ORDEN: 2
            new ComidaCarrito()
            {
                Id = 18, // PrimaryKey
                IdComboCarrito = null,  // ForeignKey: ComboCarrito [null]
                IdOrden = 2,            // Orden: 2
                IdComida = 6,           // Comida: Coca Cola (500ml)
                Cantidad = 2,           // Cantidad: 2
            }
        };
    }
}
