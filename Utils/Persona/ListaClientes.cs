using api_restaurante_hamburguesas.Models.Persona;

namespace api_restaurante_hamburguesas.Utils.Persona
{
    public class ListaClientes
    {
        public List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente
            {
                Id = 1,
                Nombre = "Christian", Apellido = "Jácome",
                FechaNacimiento = new DateTime(2003,9,29),
                IdGenero = 1,
                TelefonoCliente = "0992724743",
                MailCliente = "chrisjMora@gmail.com"
            },
            new Cliente
            {
                Id = 2,
                Nombre = "Xavier", Apellido = "Jácome",
                FechaNacimiento = new DateTime(2007,6,1),
                IdGenero = 1,
                TelefonoCliente = "0992755743",
                MailCliente = "xavierjMora@gmail.com"
            }
        };
    }
}
