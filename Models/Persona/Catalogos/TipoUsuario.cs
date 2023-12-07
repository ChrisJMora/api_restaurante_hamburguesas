using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Persona.Catalogos
{
    public class TipoUsuario
    {
        [Column("id_tipo_usuario", Order = 1)]
        [Key]
        public int TipoUsuarioId { get; set; }

        [Column("tipo_usuario", Order = 2)]
        public string? Nombre { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }
    }
}
