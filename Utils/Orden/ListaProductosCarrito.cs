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
                ProductoCarritoId = 1,  // PrimaryKey
                OrdenId = 1,            // Orden: 1   
                ComboId = 1,            // Combo: Combo Clásico
                Cantidad = 3,           // Cantidad: 3
            },
            // COMIDA DEL COMBO 1
            // [Hamburguesa Clásica, Papas Fritas Pequeñas, Coca Cola (500ml), Helado de Vainilla]
            new ComidaCarrito()
            {
                ProductoCarritoId = 2,  // PrimaryKey
                ComboCarritoId = 1,     // ForeignKey: ComboCarrito [1]
                OrdenId = 1,            // Orden: 1
                ComidaId = 1,           // Comida: Hamburguesa Clásica
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 3,  // PrimaryKey
                ComboCarritoId = 1,     // ForeignKey: ComboCarrito [1]
                OrdenId = 1,            // Orden: 1
                ComidaId = 5,           // Comida: Papas Fritas Pequeñas
                Cantidad = 5,           // Cantidad: 5
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 4,  // PrimaryKey
                ComboCarritoId = 1,     // ForeignKey: ComboCarrito [1]
                OrdenId = 1,            // Orden: 1
                ComidaId = 6,           // Comida: Coca Cola (500 ml)
                Cantidad = 5,           // Cantidad: 5
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 5,  // PrimaryKey
                ComboCarritoId = 1,     // ForeignKey: ComboCarrito [1]
                OrdenId = 1,            // Orden: 1
                ComidaId = 7,           // Comida: Helado de Vainilla
                Cantidad = 2,           // Cantidad: 2
            },

            // COMBO 2: Combo Clásico | ORDEN: 1
            new ComboCarrito()
            {
                ProductoCarritoId = 6,  // PrimaryKey
                OrdenId = 1,            // Orden: 1   
                ComboId = 1,            // Combo: Combo Clásico
                Cantidad = 2,           // Cantidad: 3
            },
            // COMIDA DEL COMBO 2
            // [Hamburguesa Clásica, Papas Fritas Grandes, Coca Cola (500ml), Helado de Chocolate]
            new ComidaCarrito()
            {
                ProductoCarritoId = 8,  // PrimaryKey
                ComboCarritoId = 5,     // ForeignKey: ComboCarrito [5]
                OrdenId = 1,            // Orden: 1
                ComidaId = 1,           // Comida: Hamburguesa Clásica
                Cantidad = 2,           // Cantidad: 2
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 9,  // PrimaryKey
                ComboCarritoId = 5,     // ForeignKey: ComboCarrito [5]
                OrdenId = 1,            // Orden: 1
                ComidaId = 4,           // Comida: Papas Fritas Grandes
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 10,  // PrimaryKey
                ComboCarritoId = 5,     // ForeignKey: ComboCarrito [5]
                OrdenId = 1,            // Orden: 1
                ComidaId = 6,           // Comida: Coca Cola (500ml)
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 11,  // PrimaryKey
                ComboCarritoId = 5,     // ForeignKey: ComboCarrito [5]
                OrdenId = 1,            // Orden: 1
                ComidaId = 8,           // Comida: Helado de Chocolate
                Cantidad = 1,           // Cantidad: 1
            },

            // COMBO 3: Combo Mini Burguer | ORDEN: 2
            new ComboCarrito()
            {
                ProductoCarritoId = 12,  // PrimaryKey
                OrdenId = 2,            // Orden: 2   
                ComboId = 3,            // Combo: Combo Mini Burguer
                Cantidad = 1,           // Cantidad: 1
            },
            // COMIDA DEL COMBO 3
            // [Mini Hamburguesa Sencilla, Papas Fritas Pequeñas, Coca Cola (500ml), Helado de Vainilla]
            new ComidaCarrito()
            {
                ProductoCarritoId = 13,  // PrimaryKey
                ComboCarritoId = 9,     // ForeignKey: ComboCarrito [9]
                OrdenId = 2,            // Orden: 2
                ComidaId = 3,           // Comida: Mini Hamburguesa Sencilla
                Cantidad = 1,           // Cantidad: 1
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 14,  // PrimaryKey
                ComboCarritoId = 9,     // ForeignKey: ComboCarrito [9]
                OrdenId = 2,            // Orden: 2
                ComidaId = 5,           // Comida: Papas Fritas Pequeñas
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 15,  // PrimaryKey
                ComboCarritoId = 9,     // ForeignKey: ComboCarrito [9]
                OrdenId = 2,            // Orden: 2
                ComidaId = 6,           // Comida: Coca Cola (500ml)
                Cantidad = 3,           // Cantidad: 3
            },
            new ComidaCarrito()
            {
                ProductoCarritoId = 16,  // PrimaryKey
                ComboCarritoId = 9,     // ForeignKey: ComboCarrito [9]
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
