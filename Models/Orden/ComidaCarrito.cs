using api_restaurante_hamburguesas.Models.Productos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Orden
{
    public class ComidaCarrito : ProductoCarrito
    {
        [Column("idComboCarrito")]
        public int? IdComboCarrito { get; set; }
        [Column("idComida")]
        [Required]
        public required int IdComida { get; set; }
        [JsonIgnore]
        public ComboCarrito? ComboCarrito { get; set; }
        [JsonIgnore]
        public Comida? Comida { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ComidaCarrito comida = (ComidaCarrito)obj;
            return IdComida == comida.IdComida;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
