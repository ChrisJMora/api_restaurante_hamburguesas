using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace api_restaurante_hamburguesas.Models.Productos
{
    public class Imagen
    {
        [Column("id_imagen")]
        [Key]
        public int ImagenId { get; set; }

        [Column("titulo_imagen")]
        [Required]
        public required string Titulo { get; set; }

        [Column("datos_imagen")]
        public required byte[] Datos { get; set; }
    }
}
