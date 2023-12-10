using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Productos.Catalogos
{
    public class CategoriaComida
    {
        [Column("idCategoriaComida", Order = 1)]
        [Key]
        public int Id { get; set; }
        [Column("etiquetaCategoriaComida", Order = 2)]
        [Required]
        public required string Etiqueta { get; set; }
        [JsonIgnore]
        public Comida? Comida { get; set; }
    }
}
