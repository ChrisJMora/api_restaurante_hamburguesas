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
        [Column("descuento_combo")]
        [Required]
        public double Descuento { get; set; }

        [Column("id_categoria_combo")]
        public int? CategoriaIdCombo { get; set; }

        [JsonIgnore]
        public CategoriaCombo? CategoriaCombo { get; set; }

        [JsonIgnore]
        public ComboComida? ComboComida { get; set; }

        [JsonIgnore]
        public ComboCarrito? ComboCarrito { get; set; }

        [Column("estado_combo")]
        [Required]
        public required int EstadoComboId { get; set; }

        [JsonIgnore]
        public Estado? EstadoCombo { get; set; }
    }
}
