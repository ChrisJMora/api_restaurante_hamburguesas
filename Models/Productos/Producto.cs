using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Productos
{
    public class Producto
    {
        [Column("idProducto", Order = 1)]
        [Required]
        [Key]
        public int Id { get; set; }
        [Column("nombreProducto", Order = 2)]
        [Required]
        public required string Nombre {  get; set; }
        [Column("descripcionProducto", Order = 3)]
        [Required]
        public required string Descripcion {  get; set; }

    }
}
