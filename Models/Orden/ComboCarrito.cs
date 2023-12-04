using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Productos;

namespace api_restaurante_hamburguesas.Models.Orden
{
    public class ComboCarrito : ProductoCarrito
    {
        [Column("id_combo_combo_carrito")]
        [Required]
        public int ComboId { get; set; }

        [JsonIgnore]
        public Combo? Combo { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ComboCarrito combo = (ComboCarrito)obj;
            return ComboId == combo.ComboId;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
