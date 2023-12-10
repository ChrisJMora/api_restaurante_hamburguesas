using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Productos.Catalogos
{
    public class CategoriaCombo
    {
        [Column("idCategoriaCombo", Order = 1)]
        [Key]
        public int Id { get; set; }
        [Column("etiquetaCategoriaCombo", Order = 2)]
        [Required]
        public required string Etiqueta { get; set; }
        [JsonIgnore]
        public Combo? Combo { get; set; }
    }
}
