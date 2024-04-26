using System;
using System.ComponentModel.DataAnnotations;

namespace LionDev.Models
{
    public class Usuario
    {
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

        /*[Required]
        [StringLength(30, MinimumLength = 3)]
        public string TipoDeDocumento { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 5)]
        public string NumeroDeDocumento { get; set; }*/

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{5,30}$",
            ErrorMessage = "La contraseña debe tener mayúsculas, minúsculas y números")]
        public string Contrasena { get; set; }

        /*[StringLength(9, MinimumLength = 8)]
        public string Genero { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 7)]
        public string Direccion { get; set; }*/

        //[Required]
        [StringLength(30, MinimumLength = 3)]
        public string Rol { get; set; }

        //public ICollection<Factura>? Factura { get; set; }
    }

}
