using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using api_restaurante_hamburguesas.Models.Persona.Catalogos;
using api_restaurante_hamburguesas.Models.Orden;

namespace api_restaurante_hamburguesas.Models.Persona
{
    public class Cliente
    {
        [Column("idCliente", Order = 1)]
        [Key]
        public int Id { get; set; }
        [Column("nombreCliente", Order = 2)]
        [Required]
        public required string Nombre { get; set; }
        [Column("apellido", Order = 3)]
        [Required]
        public required string Apellido { get; set; }
        [Column("fechaNcliente", Order = 4)]
        [Required]
        public required DateTime? FechaNacimiento { get; set; }
        [Column("idGeneroCliente", Order = 5)]
        [Required]
        public required int IdGenero { get; set; }
        [Column("telefono", Order = 6)]
        [Required]
        public required string TelefonoCliente { get; set; }
        [Column("mail", Order = 7)]
        [Required]
        public required string MailCliente { get; set; }
        [JsonIgnore]
        public GeneroCliente? Genero { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        [JsonIgnore]
        public Orden.Orden? Orden { get; set; }
    }
}
