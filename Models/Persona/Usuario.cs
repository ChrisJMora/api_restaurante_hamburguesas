using api_restaurante_hamburguesas.Models.Persona.Catalogos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace api_restaurante_hamburguesas.Models.Persona
{
    [Index(nameof(NombreUsuario), IsUnique = true)]
    public class Usuario
    {
        private const int tamanioSalt = 64;
        private PasswordHasher<string> _passwordHasher = new PasswordHasher<string>();

        [Column("id_usuario", Order = 1)]
        [Key]
        public int UsuarioId { get; set; }

        [Column("id_tipo_usuario", Order = 2)]
        [Required]
        public required int TipoUsuarioId { get; set; }

        [Column("nombre_usuario", Order = 3)]
        [Required]
        public required string NombreUsuario { get; set; }

        [Column("salt_password", Order = 4)]
        [Required]
        public string SaltPassword { get; private set; } = "default";

        [Column("password_usuario", Order = 5)]
        [Required]
        public string PasswordUsuario { get; private set; } = "default";

        [Column("fecha_creacion", Order = 6)]
        [Required]
        public required DateTime FechaCreacion { get; set; }

        [Column("fecha_acceso", Order = 7)]
        [Required]
        public DateTime? FechaAcceso { get; set; }

        [Column("estado_usuario", Order = 8)]
        [Required]
        public required int EstadoUsuarioId { get; set; }

        [Column("id_cliente", Order = 9)]
        public int? ClienteId { get; set; }

        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        [JsonIgnore]
        public TipoUsuario? TipoUsuario { get; set; }

        [JsonIgnore]
        public EstadoUsuario? EstadoUsuario { get; set; }

        public void EncriptarPassword()
        {
            var byteSalt = RandomNumberGenerator.GetBytes(tamanioSalt);
            SaltPassword = Convert.ToHexString(byteSalt);
            PasswordUsuario = _passwordHasher.HashPassword(null, SaltPassword + PasswordUsuario);
        }

        public void EncriptarPassword(string password)
        {
            var byteSalt = RandomNumberGenerator.GetBytes(tamanioSalt);
            SaltPassword = Convert.ToHexString(byteSalt);
            PasswordUsuario = _passwordHasher.HashPassword(null, SaltPassword + password);
        }

    }
}