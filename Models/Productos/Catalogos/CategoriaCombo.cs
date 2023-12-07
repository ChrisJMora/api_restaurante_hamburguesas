using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Productos.Catalogos
{
    public class CategoriaCombo
    {
        [Column("id_categoria_combo")]
        [Key]
        public int CategoriaIdCombo { get; set; }

        [Column("nombre_categoria_combo")]
        [Required]
        public string? Nombre { get; set; }

        [JsonIgnore]
        public Combo? Combo { get; set; }
    }
}
