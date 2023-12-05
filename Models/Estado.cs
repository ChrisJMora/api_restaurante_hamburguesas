using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Persona;
using api_restaurante_hamburguesas.Models.Productos;

namespace api_restaurante_hamburguesas.Models
{
    public class Estado
    {
        [Column("id_estado", Order = 1)]
        [Key]
        public int EstadoUsuarioId { get; set; }

        [Column("nombre_estado", Order = 2)]
        public string? Nombre { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }

        [JsonIgnore]
        public Comida? Comida { get; set; }

        [JsonIgnore]
        public Combo? Combo { get; set; }
    }
}
