using api_restaurante_hamburguesas.Models.Persona;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Orden
{
    public class Orden
    {
        [Column("idOrden", Order = 1)]
        [Required]
        [Key]
        public int Id { get; set; }
        [Column("fechaOrden", Order = 2)]
        [Required]
        public required DateTime Fecha { get; set; }
        [Column("idClienteOrden", Order = 3)]
        [Required]
        public required int IdCliente { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }
        [JsonIgnore]    
        public ProductoCarrito? Carrito { get; set; }
    }
}
