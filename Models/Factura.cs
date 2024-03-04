using System.ComponentModel.DataAnnotations.Schema;

namespace LionDev.Models
{
    public class Factura
    {
        public Guid IdFactura { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public required decimal Valor { get; set; }
        public required DateTime FechaYHora { get; set; }
        public required bool Pagado { get; set; }

        public Guid IdComprador { get; set; }
        public required Usuario Comprador { get; set; }

        public required ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
