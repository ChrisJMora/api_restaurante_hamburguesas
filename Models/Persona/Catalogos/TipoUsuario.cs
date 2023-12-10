using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Persona.Catalogos
{
    public class TipoUsuario
    {
        [Column("idTipo", Order = 1)]
        [Key]
        public int Id { get; set; }
        [Column("etiquetaTipo", Order = 2)]
        public required string Etiqueta { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
    }
}
