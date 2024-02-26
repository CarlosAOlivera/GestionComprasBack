using System;
using System.ComponentModel.DataAnnotations;

namespace LionDev.Models
{
    public class Comprador
    {
        [Key]
        public Guid IdComprador { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 9)]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string TipoDeDocumento { get; set; }

        [Required]
        [Range(10000, 9999999999999999)]
        public int NumeroDeDocumento { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        [RegularExpression("(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{5,}")]
        public string Contrasena { get; set; }

        [StringLength(9, MinimumLength = 8)]
        public string Genero { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 7)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Rol { get; set; }

        //public ICollection<Factura>? Factura { get; set; }
    }
}

