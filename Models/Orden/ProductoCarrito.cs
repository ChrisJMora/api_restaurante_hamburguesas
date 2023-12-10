using api_restaurante_hamburguesas.Models.Productos;
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Orden
{
    public class ProductoCarrito
    {
        [Column("idCarrito", Order = 1)]
        [Key]
        [Required]
        public int Id { get; set; }
        [Column("idOrdenCarrito", Order = 2)]
        [Required]
        public required int IdOrden { get; set; }
        [Column("cantidad", Order = 3)]
        [Required]
        public required int Cantidad { get; set; }
        [JsonIgnore]
        public Orden? Orden { get; set; }
    }
}
