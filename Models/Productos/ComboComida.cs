using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Productos
{
    public class ComboComida
    {
        [Column("combo_comida_id")]
        [Key]
        public int ComboComidaId { get; set; }

        [Column("id_combo")]
        public int IdCombo { get; set; }

        [Column("id_comida")]
        public int IdComida { get; set; }

        [Column("cantidad_combo_comida")]
        public int Cantidad { get; set; }

        [JsonIgnore]
        public Combo? Combo { get; set; }

        [JsonIgnore]
        public Comida? Comida { get; set; }
    }
}
