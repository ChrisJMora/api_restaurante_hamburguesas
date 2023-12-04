using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Persona.Catalogos;
using api_restaurante_hamburguesas.Models.Orden;

namespace api_restaurante_hamburguesas.Models.Persona
{
    public class Cliente
    {
        [Column("id_cliente", Order = 1)]
        [Key]
        public int ClienteId { get; set; }

        [Column("nombre_cliente", Order = 2)]
        [Required]
        public string? Nombre { get; set; }

        [Column("apellido_cliente", Order = 3)]
        [Required]
        public string? Apellido { get; set; }

        [Column("fechaN_cliente", Order = 4)]
        [Required]
        public DateTime? FechaNacimiento { get; set; }

        [JsonIgnore]
        public GeneroCliente? Genero { get; set; }

        [Column("id_genero_cliente", Order = 5)]
        [Required]
        public int GeneroId_Cliente { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }

        [JsonIgnore]
        public Orden.Orden? Orden { get; set; }
    }
}
