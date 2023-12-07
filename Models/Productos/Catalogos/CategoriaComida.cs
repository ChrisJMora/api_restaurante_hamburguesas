using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Productos.Catalogos
{
    public class CategoriaComida
    {
        [Column("id_categoria_comida")]
        [Key]
        public int CategoriaIdComida { get; set; }

        [Column("nombre_categoria_comida")]
        [Required]
        public string? Nombre { get; set; }

        [JsonIgnore]
        public Comida? Comida { get; set; }

    }
}
