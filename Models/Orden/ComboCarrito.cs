using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Productos;

namespace api_restaurante_hamburguesas.Models.Orden
{
    public class ComboCarrito : ProductoCarrito
    {
        [Column("idCombo")]
        [Required]
        public int IdCombo { get; set; }
        [JsonIgnore]
        public Combo? Combo { get; set; }
        [JsonIgnore]
        public ComidaCarrito? ComidaCarrito { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ComboCarrito combo = (ComboCarrito)obj;
            return IdCombo == combo.IdCombo;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
