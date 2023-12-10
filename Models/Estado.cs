using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Persona;
using api_restaurante_hamburguesas.Models.Productos;

namespace api_restaurante_hamburguesas.Models
{
    public class Estado
    {
        [Column("idEstado", Order = 1)]
        [Key]
        public int Id { get; set; }
        [Column("etiquetaEstado", Order = 2)]
        public required string Etiqueta { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        [JsonIgnore]
        public Comida? Comida { get; set; }
        [JsonIgnore]
        public Combo? Combo { get; set; }
    }
}
