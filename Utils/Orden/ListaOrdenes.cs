namespace api_restaurante_hamburguesas.Models.Orden
{
    public class ListaOrdenes
    {
        public List<Orden> listaOrdenes = new List<Orden>()
        {
            // ORDEN 1: MONSE HERRERA
            new Orden() { OrdenId = 1, ClienteId = 1, Fecha = DateTime.Now },
            // ORDEN 2: CHRISTIAN JÁCOME
            new Orden() { OrdenId = 2, ClienteId = 2, Fecha = DateTime.Now },
        };
    }
}
