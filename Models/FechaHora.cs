using Microsoft.Identity.Client;

namespace api_restaurante_hamburguesas.Models
{
    public class FechaHora
    {
        private DateTime _fechaHoraLocal;
        public FechaHora()
        {
            // Get the current UTC time
            DateTime currentUtcTime = DateTime.UtcNow;

            // Define the timezone (for example, "Eastern Standard Time")
            TimeZoneInfo easternTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            // Convert UTC time to the desired timezone
            _fechaHoraLocal = TimeZoneInfo.ConvertTimeFromUtc(currentUtcTime, easternTimeZone);
        }

        public DateTime ObtenerFechaHoraLocal() { return _fechaHoraLocal; } 
    }
}
