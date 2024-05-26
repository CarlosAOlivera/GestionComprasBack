using System;
using System.ComponentModel.DataAnnotations;

namespace LionDev.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public Guid IdUsuario { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 9)]
        public string CorreoElectronico { get; set; }

        public bool EmailConfirmado { get; set; }
        public string? ConfirmationToken { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{5,30}$",
            ErrorMessage = "La contraseña debe tener mayúsculas, minúsculas y números")]
        public string Contrasena { get; set; }

        //[Required]
        [StringLength(30, MinimumLength = 3)]
        public string Rol { get; set; }

        public DateTime FechaRegistro { get; set; }

        //public ICollection<Factura>? Factura { get; set; }
    }

}
