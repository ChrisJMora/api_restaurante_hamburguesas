using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Productos.Catalogos;
using api_restaurante_hamburguesas.Models.Orden;

namespace api_restaurante_hamburguesas.Models.Productos
{
    public class Combo : Producto
    {
        [Column("descuento_combo")]
        [Required]
        public double Descuento { get; set; }

        [Column("disponibilidad_combo")]
        [Required]
        public bool Disponibilidad { get; set; }

        [Column("id_categoria_combo")]
        [Required]
        public int CategoriaId_Combo { get; set; }

        [JsonIgnore]
        public CategoriaCombo? CategoriaCombo { get; set; }

        [JsonIgnore]
        public ComboComida? ComboComida { get; set; }

        [JsonIgnore]
        public ComboCarrito? ComboCarrito { get; set; }
    }
}
