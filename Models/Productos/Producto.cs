using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Productos
{
    public class Producto
    {
        [Column("id_producto")]
        [Required]
        [Key]
        public int ProductoId { get; set; }
        [Column("nombre_producto")]
        [Required]
        public required string Nombre {  get; set; }
        [Column("descripcion_producto")]
        [Required]
        public required string Descripcion {  get; set; }

    }
}
