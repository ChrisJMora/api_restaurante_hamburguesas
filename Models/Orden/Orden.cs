using api_restaurante_hamburguesas.Models.Persona;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Orden
{
    public class Orden
    {
        [Column("id_orden")]
        [Required]
        [Key]
        public int OrdenId { get; set; }

        [Column("fecha_compra_orden")]
        [Required]
        public DateTime Fecha { get; set; }

        [Column("cliente_id_orden")]
        [Required]
        public int ClienteId { get; set; }

        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        [JsonIgnore]    
        public ProductoCarrito? Carrito { get; set; }
    }
}
