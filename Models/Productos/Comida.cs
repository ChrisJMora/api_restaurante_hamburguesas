using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Productos.Catalogos;
using api_restaurante_hamburguesas.Models.Orden;

namespace api_restaurante_hamburguesas.Models.Productos
{
    public class Comida : Producto
    {
        [Column("precio_comida")]
        [Required]
        public double? Precio { get; set; }

        [Column("id_categoria_comida")]
        [Required]
        public int CategoriaId_Comida { get; set; }

        [JsonIgnore]
        public CategoriaComida? CategoriaComida { get; set; }

        [JsonIgnore]
        public ComboComida? ComboComida { get; set; }

        [JsonIgnore]
        public ComidaCarrito? ComidaCarrito { get; set; }
    }
}
