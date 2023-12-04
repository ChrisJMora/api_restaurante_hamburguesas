using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Persona.Catalogos
{
    public class EstadoUsuario
    {
        [Column("id_estado_usuario", Order = 1)]
        public int EstadoUsuarioId { get; set; }

        [Column("estado_usuario", Order = 2)]
        public string? Estado { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }
    }
}
