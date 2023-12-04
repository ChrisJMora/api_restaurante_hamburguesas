using api_restaurante_hamburguesas.Models.Productos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Orden
{
    public class ComidaCarrito : ProductoCarrito
    {
        [Column("id_combo_comida_carrito)")]
        public int? ComboCarritoId { get; set; }

        [Column("id_comida_comida_carrito")]
        [Required]
        public int ComidaId { get; set; }

        [JsonIgnore]
        public ComboCarrito? ComboCarrito { get; set; }

        [JsonIgnore]
        public Comida? Comida { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ComidaCarrito comida = (ComidaCarrito)obj;
            return ComidaId == comida.ComidaId;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
