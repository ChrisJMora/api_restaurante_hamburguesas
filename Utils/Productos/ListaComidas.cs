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
                ProductoId = 1,
                Nombre = "Hamburguesa Clásica",
                Descripcion = """
                Una hamburguesa con queso, lechuga, tomate, cebolla y salsa especial.
                """,
                Precio = 5.5f,
                CategoriaId_Comida = 1
            },

            new Comida
            {
                ProductoId = 2,
                Nombre = "Hamburguesa Doble",
                Descripcion = """
                Doble carne con queso, tocino, lechuga, tomate y aderezos.
                """,
                Precio = 7.5f,
                CategoriaId_Comida = 1
            },

            new Comida
            {
                ProductoId = 3,
                Nombre = "Mini Hamburguesa Sencilla",
                Descripcion = """
                Una hamburguesa más pequeña con queso y vegetales básicos.
                """,
                Precio = 3.5f,
                CategoriaId_Comida = 1
            },


            //COMPLEMENTOS
            new Comida
            {
                ProductoId = 4,
                Nombre = "Papas Fritas Grandes",
                Descripcion = "Papas fritas grandes",
                Precio = 2.5f,
                CategoriaId_Comida = 3
            },

            new Comida
            {
                ProductoId = 5,
                Nombre = "Papas Fritas Pequeñas",
                Descripcion = "Papas fritas pequeñas",
                Precio = 1.5f,
                CategoriaId_Comida = 3
            },

            //BEBIDAS
            new Comida
            {
                ProductoId = 6,
                Nombre = "Coca Cola (500ml)",
                Descripcion = "Coca Cola personal de 500 ml",
                Precio = 2.5f,
                CategoriaId_Comida = 2
            },

            //POSTRES
            new Comida
            {
                ProductoId = 7,
                Nombre = "Helado de Vainilla",
                Descripcion = "Helado de vainilla",
                Precio = 1.5f,
                CategoriaId_Comida = 4
            },

            new Comida
            {
                ProductoId = 8,
                Nombre = "Helado de Chocolate",
                Descripcion = "Helado de chocalate",
                Precio = 1.5f,
                CategoriaId_Comida = 4
            }

        };
    }
}
