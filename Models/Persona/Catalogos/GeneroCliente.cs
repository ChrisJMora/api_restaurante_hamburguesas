using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Persona.Catalogos
{
    public class GeneroCliente
    {
        [Column("id_genero", Order = 1)]
        [Key]
        public int GeneroId { get; set; }
        [Column("genero_cliente", Order = 2)]
        public string? Genero { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }
    }
}
