using System;
using System.ComponentModel.DataAnnotations;

namespace LionDev.Models
{
    public class Comprador
    {
        public required Guid IdComprador { get; set; }
                
        //longitud mínima 3, máxima 30
        public required string Nombres { get; set; }
        
        //longitud mínima 3, máxima 30        
        public required string Apellidos { get; set; }

        //longitud mínima 9, máxima 30
        public required string CorreoElectronico { get; set; }

        //longitud mínima 3, máxima 30
        public required string TipoDeDocumento { get; set; }

        //longitud mínima 5, máxima 16
        public required int NumeroDeDocumento { get; set; }

        //Longitud mínima 5, máxima 30, debe tener mayúsculas, minúsculas y números
        public required string Contrasena { get; set; }

        //longitud mínima 8, máxima 9
        public string? Genero { get; set; }

        //longitud mínima 7, máxima 30
        public required string Direccion { get; set; }        

        //Longitud mínima 3, máxima de 30
        public required string Rol { get; set; }

        //public ICollection<Factura>? Factura { get; set; }
    }
}
