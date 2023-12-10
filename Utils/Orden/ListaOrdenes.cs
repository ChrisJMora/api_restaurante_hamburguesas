namespace api_restaurante_hamburguesas.Models.Orden
{
    public class ListaOrdenes
    {
        public List<Orden> listaOrdenes = new List<Orden>()
        {
            // ORDEN 1: MONSE HERRERA
            new Orden() { Id = 1, IdCliente = 1, Fecha = DateTime.Now },
            // ORDEN 2: CHRISTIAN JÁCOME
            new Orden() { Id = 2, IdCliente = 2, Fecha = DateTime.Now },
        };
    }
}
