using api_restaurante_hamburguesas.Models.Productos;

namespace api_restaurante_hamburguesas.Utils.Productos
{
    public class ListaComboComida
    {
        public List<ComboComida> listaComboComida = new List<ComboComida>()
        {
        // COMBO CLÁSICO [1]
            // HAMBURGUESA CLÁSICA
            new ComboComida() { ComboComidaId = 1, IdCombo = 1, IdComida = 1, Cantidad = 1},
        // COMPLEMENTOS
            // PAPAS FRITAS GRANDES
            new ComboComida() { ComboComidaId = 2, IdCombo = 1, IdComida = 4, Cantidad = 1},
            // PAPAS FRITAS PEQUEÑAS
            new ComboComida() { ComboComidaId = 3, IdCombo = 1, IdComida = 5, Cantidad = 3},
        // BEBIDAS
            // COCA COLA (500 ml)
            new ComboComida() { ComboComidaId = 4, IdCombo = 1, IdComida = 6, Cantidad = 1},
        // POSTRES
            // HELADO DE VAINILLA
            new ComboComida() { ComboComidaId = 5, IdCombo = 1, IdComida = 7, Cantidad = 1},
            // HELADO DE CHOCOLATE
            new ComboComida() { ComboComidaId = 6, IdCombo = 1, IdComida = 8, Cantidad = 1},

        // COMBO PARA TODOS [2]
            // HAMBURGUESA DOBLE
            new ComboComida() { ComboComidaId = 7, IdCombo = 2, IdComida = 2, Cantidad = 3},
        // COMPLEMENTOS
            // PAPAS FRITAS GRANDES
            new ComboComida() { ComboComidaId = 8, IdCombo = 2, IdComida = 4, Cantidad = 3},
            // PAPAS FRITAS PEQUEÑAS
            new ComboComida() { ComboComidaId = 9, IdCombo = 2, IdComida = 5, Cantidad = 6},
        // BEBIDAS
            // COCA COLA (500 ml)
            new ComboComida() { ComboComidaId = 10, IdCombo = 2, IdComida = 6, Cantidad = 3},
        // POSTRES
            // HELADO DE VAINILLA
            new ComboComida() { ComboComidaId = 11, IdCombo = 2, IdComida = 7, Cantidad = 2},
            // HELADO DE CHOCOLATE
            new ComboComida() { ComboComidaId = 12, IdCombo = 2, IdComida = 8, Cantidad = 2},

        // COMBO MINI BURGUER [3]
            // MINI HAMBURGUESA SENCILLA
            new ComboComida() { ComboComidaId = 13, IdCombo = 3, IdComida = 3, Cantidad = 1},
        // COMPLEMENTOS
            // PAPAS FRITAS PEQUEÑAS
            new ComboComida() { ComboComidaId = 14, IdCombo = 3, IdComida = 5, Cantidad = 1},
        // BEBIDAS
            // COCA COLA (500 ml)
            new ComboComida() { ComboComidaId = 15, IdCombo = 3, IdComida = 6, Cantidad = 1},
        // POSTRES
            // HELADO DE VAINILLA
            new ComboComida() { ComboComidaId = 16, IdCombo = 3, IdComida = 7, Cantidad = 1},
            // HELADO DE CHOCOLATE
            new ComboComida() { ComboComidaId = 17, IdCombo = 3, IdComida = 8, Cantidad = 1},
        };
    }
}
