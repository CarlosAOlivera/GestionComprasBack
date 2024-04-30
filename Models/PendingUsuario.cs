using System;
using System.ComponentModel.DataAnnotations;

namespace LionDev.Models

{
    public class PendingUsuario
    {
        [Key]
        public Guid Id { get; set; }
        public string CorreoElectronico { get; set; }
        public string ConfirmationToken { get; set; }
        public bool EmailConfirmado { get; set; }
    }
}
