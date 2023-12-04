using api_restaurante_hamburguesas.Models.Orden;

namespace api_restaurante_hamburguesas.Utils.Orden
{
    public class ListaComidasCarrito
    {
        public List<ComidaCarrito> listaComidasCarrito = new List<ComidaCarrito>()
        {

            // COMIDA DEL COMBO: 1 | ORDEN: 1
            // [Hamburguesa Clásica, Papas Fritas Pequeñas, Coca Cola (500ml), Helado de Vainilla]
            new ComidaCarrito()
            {
                ProductoCarritoId = 4,  // PrimaryKey
                ComboCarritoId = 1,     // ForeignKey: ComboCarrito [1]
                OrdenId = 1,            // Orden: 1
                ComidaId = 1,           // Comida: Hamburguesa Clásica
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 5,  // PrimaryKey
                ComboCarritoId = 1,     // ForeignKey: ComboCarrito [1]
                OrdenId = 1,            // Orden: 1
                ComidaId = 5,           // Comida: Papas Fritas Pequeñas
                Cantidad = 5,           // Cantidad: 5
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 6,  // PrimaryKey
                ComboCarritoId = 1,     // ForeignKey: ComboCarrito [1]
                OrdenId = 1,            // Orden: 1
                ComidaId = 6,           // Comida: Coca Cola (500 ml)
                Cantidad = 5,           // Cantidad: 5
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 7,  // PrimaryKey
                ComboCarritoId = 1,     // ForeignKey: ComboCarrito [1]
                OrdenId = 1,            // Orden: 1
                ComidaId = 7,           // Comida: Helado de Vainilla
                Cantidad = 2,           // Cantidad: 2
            },

            // COMIDA DEL COMBO: 2 | ORDEN: 1
            // [Hamburguesa Clásica, Papas Fritas Grandes, Coca Cola (500ml), Helado de Chocolate]
            new ComidaCarrito()
            {
                ProductoCarritoId = 8,  // PrimaryKey
                ComboCarritoId = 2,     // ForeignKey: ComboCarrito [5]
                OrdenId = 1,            // Orden: 1
                ComidaId = 1,           // Comida: Hamburguesa Clásica
                Cantidad = 2,           // Cantidad: 2
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 9,  // PrimaryKey
                ComboCarritoId = 2,     // ForeignKey: ComboCarrito [5]
                OrdenId = 1,            // Orden: 1
                ComidaId = 4,           // Comida: Papas Fritas Grandes
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 10,  // PrimaryKey
                ComboCarritoId = 2,     // ForeignKey: ComboCarrito [5]
                OrdenId = 1,            // Orden: 1
                ComidaId = 6,           // Comida: Coca Cola (500ml)
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 11,  // PrimaryKey
                ComboCarritoId = 2,     // ForeignKey: ComboCarrito [5]
                OrdenId = 1,            // Orden: 1
                ComidaId = 8,           // Comida: Helado de Chocolate
                Cantidad = 1,           // Cantidad: 1
            },

            // COMIDA DEL COMBO: 3 | ORDEN: 2
            // [Mini Hamburguesa Sencilla, Papas Fritas Pequeñas, Coca Cola (500ml), Helado de Vainilla]
            new ComidaCarrito()
            {
                ProductoCarritoId = 13,  // PrimaryKey
                ComboCarritoId = 3,     // ForeignKey: ComboCarrito [9]
                OrdenId = 2,            // Orden: 2
                ComidaId = 3,           // Comida: Mini Hamburguesa Sencilla
                Cantidad = 1,           // Cantidad: 1
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 14,  // PrimaryKey
                ComboCarritoId = 3,     // ForeignKey: ComboCarrito [9]
                OrdenId = 2,            // Orden: 2
                ComidaId = 5,           // Comida: Papas Fritas Pequeñas
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 15,  // PrimaryKey
                ComboCarritoId = 3,     // ForeignKey: ComboCarrito [9]
                OrdenId = 2,            // Orden: 2
                ComidaId = 6,           // Comida: Coca Cola (500ml)
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 16,  // PrimaryKey
                ComboCarritoId = 3,     // ForeignKey: ComboCarrito [9]
                OrdenId = 2,            // Orden: 2
                ComidaId = 7,           // Comida: Helado de Vainilla
                Cantidad = 3,           // Cantidad: 3
            },

            // COMIDA QUE NO FORMA PARTE DE UN COMBO
            // HAMBURGUESA DOBLE | ORDEN: 2
            new ComidaCarrito()
            {
                ProductoCarritoId = 17, // PrimaryKey
                ComboCarritoId = null,  // ForeignKey: ComboCarrito [null]
                OrdenId = 2,            // Orden: 2
                ComidaId = 2,           // Comida: Hamburguesa Doble
                Cantidad = 4,           // Cantidad: 4
            },
            // COCA COLA (500ml) | ORDEN: 2
            new ComidaCarrito()
            {
                ProductoCarritoId = 18, // PrimaryKey
                ComboCarritoId = null,  // ForeignKey: ComboCarrito [null]
                OrdenId = 2,            // Orden: 2
                ComidaId = 6,           // Comida: Coca Cola (500ml)
                Cantidad = 2,           // Cantidad: 2
            }
        };
    }
}
