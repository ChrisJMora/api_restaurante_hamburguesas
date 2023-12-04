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
        [Column("id_carrito")]
        [Key]
        [Required]
        public int ProductoCarritoId { get; set; }

        [Column("id_orden_carrito")]
        [Required]
        public int OrdenId { get; set; }

        [Column("id_cantidad_carrito")]
        [Required]
        public int Cantidad { get; set; }

        [JsonIgnore]
        public Orden? Orden { get; set; }
    }
}
