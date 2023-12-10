using api_restaurante_hamburguesas.Models.Productos;

namespace api_restaurante_hamburguesas.Utils.Productos
{
    public class ListaComidas
    {
        public List<Comida> listaComidas = new List<Comida>()
        {
            //HAMBURGUESAS
            new Comida
            {
                Id = 1,
                Nombre = "Hamburguesa Clásica",
                IdEstadoComida = 1,
                Descripcion = """
                Una hamburguesa con queso, lechuga, tomate, cebolla y salsa especial.
                """,
                Precio = 5.5f,
                IdCategoriaComida = 1
            },

            new Comida
            {
                Id = 2,
                Nombre = "Hamburguesa Doble",
                IdEstadoComida = 1,
                Descripcion = """
                Doble carne con queso, tocino, lechuga, tomate y aderezos.
                """,
                Precio = 7.5f,
                IdCategoriaComida = 1
            },

            new Comida
            {
                Id = 3,
                Nombre = "Mini Hamburguesa Sencilla",
                IdEstadoComida = 1,
                Descripcion = """
                Una hamburguesa más pequeña con queso y vegetales básicos.
                """,
                Precio = 3.5f,
                IdCategoriaComida = 1
            },


            //COMPLEMENTOS
            new Comida
            {
                Id = 4,
                Nombre = "Papas Fritas Grandes",
                IdEstadoComida = 1,
                Descripcion = "Papas fritas grandes",
                Precio = 2.5f,
                IdCategoriaComida = 3
            },

            new Comida
            {
                Id = 5,
                Nombre = "Papas Fritas Pequeñas",
                IdEstadoComida = 1,
                Descripcion = "Papas fritas pequeñas",
                Precio = 1.5f,
                IdCategoriaComida = 3
            },

            //BEBIDAS
            new Comida
            {
                Id = 6,
                Nombre = "Coca Cola (500ml)",
                IdEstadoComida = 1,
                Descripcion = "Coca Cola personal de 500 ml",
                Precio = 2.5f,
                IdCategoriaComida = 2
            },

            //POSTRES
            new Comida
            {
                Id = 7,
                Nombre = "Helado de Vainilla",
                IdEstadoComida = 1,
                Descripcion = "Helado de vainilla",
                Precio = 1.5f,
                IdCategoriaComida = 4
            },

            new Comida
            {
                Id = 8,
                Nombre = "Helado de Chocolate",
                IdEstadoComida = 1,
                Descripcion = "Helado de chocalate",
                Precio = 1.5f,
                IdCategoriaComida = 4
            }

        };
    }
}
