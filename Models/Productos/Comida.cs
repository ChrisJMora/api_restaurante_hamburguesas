using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Productos.Catalogos;
using api_restaurante_hamburguesas.Models.Orden;
using System.Diagnostics.CodeAnalysis;

namespace api_restaurante_hamburguesas.Models.Productos
{
    public class Comida : Producto
    {
        [Column("precio")]
        [Required]
        public required double Precio { get; set; }
        [Column("idCategoriaComida")]
        public required int IdCategoriaComida { get; set; }
        [Column("idEstadoComida")]
        [Required]
        public required int IdEstadoComida { get; set; }
        [JsonIgnore]
        public CategoriaComida? CategoriaComida { get; set; }
        [JsonIgnore]
        public ComidaCombo? ComboComida { get; set; }
        [JsonIgnore]
        public ComidaCarrito? ComidaCarrito { get; set; }
        [JsonIgnore]
        public Estado? EstadoComida { get; set; }
    }
}
