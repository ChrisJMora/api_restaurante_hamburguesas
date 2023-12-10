using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Productos
{
    public class ComidaCombo
    {
        [Column("idComidaCombo")]
        [Key]
        public int Id { get; set; }
        [Column("idCombo", Order = 1)]
        public required int IdCombo { get; set; }
        [Column("idComida", Order = 2)]
        public required int IdComida { get; set; }
        [Column("cantidadComidaCombo", Order = 3)]
        public required int Cantidad { get; set; }
        [JsonIgnore]
        public Combo? Combo { get; set; }
        [JsonIgnore]
        public Comida? Comida { get; set; }
    }
}
