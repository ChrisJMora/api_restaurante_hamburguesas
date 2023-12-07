using api_restaurante_hamburguesas.Models.Persona;

namespace api_restaurante_hamburguesas.Utils.Persona
{
    public class ListaClientes
    {
        public List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente
            {
                ClienteId = 1,
                Nombre = "Christian", Apellido = "Jácome",
                FechaNacimiento = new DateTime(2003,9,29),
                GeneroId = 1,
                TelefonoCliente = "0992724743",
                MailCliente = "chrisjMora@gmail.com"
            },
            new Cliente
            {
                ClienteId = 2,
                Nombre = "Xavier", Apellido = "Jácome",
                FechaNacimiento = new DateTime(2007,6,1),
                GeneroId = 1,
                TelefonoCliente = "0992755743",
                MailCliente = "xavierjMora@gmail.com"
            }
        };
    }
}
