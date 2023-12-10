using api_restaurante_hamburguesas.Models.Persona.Catalogos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Persona
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Usuario
    {
        private PasswordHasher<string> _passwordHasher = new PasswordHasher<string>();
        private const int tamanioSalt                  = 64;
        [Column("idUsuario", Order = 1)]
        [Key]
        public int Id { get; set; }
        [Column("idTipoUsuario", Order = 2)]
        [Required]
        public required int IdTipoUsuario { get; set; }
        [Column("nombreUsuario", Order = 3)]
        [Required]
        public required string Nombre { get; set; }
        [Column("saltPassword", Order = 4)]
        [Required]
        public string SaltPassword { get; private set; } = "default";
        [Column("password", Order = 5)]
        [Required]
        public string Password { get; private set; } = "default";
        [Column("fechaCreacion", Order = 6)]
        [Required]
        public required DateTime FechaCreacion { get; set; }
        [Column("fechaAcceso", Order = 7)]
        [Required]
        public required DateTime FechaAcceso { get; set; }
        [Column("idEstadoUsuario", Order = 8)]
        [Required]
        public required int IdEstadoUsuario { get; set; }
        [Column("idCliente", Order = 9)]
        public int? IdCliente { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }
        [JsonIgnore]
        public TipoUsuario? TipoUsuario { get; set; }
        [JsonIgnore]
        public Estado? EstadoUsuario { get; set; }
        public void EncriptarPassword()
        {
            var byteSalt = RandomNumberGenerator.GetBytes(tamanioSalt);
            SaltPassword = Convert.ToHexString(byteSalt);
            Password = _passwordHasher.HashPassword(Nombre, SaltPassword + Password);
        }
        public void EncriptarPassword(string password)
        {
            var byteSalt = RandomNumberGenerator.GetBytes(tamanioSalt);
            SaltPassword = Convert.ToHexString(byteSalt);
            Password = _passwordHasher.HashPassword(Nombre, SaltPassword + password);
        }
    }
}