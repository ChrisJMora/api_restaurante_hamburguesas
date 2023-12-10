using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Productos.Catalogos;
using api_restaurante_hamburguesas.Models.Orden;
using System.Diagnostics.CodeAnalysis;

namespace api_restaurante_hamburguesas.Models.Productos
{
    public class Combo : Producto
    {
        [Column("descuento")]
        [Required]
        public required double Descuento { get; set; }
        [Column("idEstadoCombo")]
        [Required]
        public required int IdEstadoCombo { get; set; }
        [Column("idCategoriaCombo")]
        public required int IdCategoriaCombo { get; set; }
        [JsonIgnore]
        public CategoriaCombo? CategoriaCombo { get; set; }
        [JsonIgnore]
        public ComidaCombo? ComboComida { get; set; }
        [JsonIgnore]
        public ComboCarrito? ComboCarrito { get; set; }
        [JsonIgnore]
        public Estado? EstadoCombo { get; set; }
    }
}
