namespace LionDev.Models
{
    public class DetalleFactura
    {
        public Guid IdDetalleFactura { get; set; }
        public required int Cantidad { get; set; }

        public Guid IdFactura { get; set; }
        public required Factura Factura { get; set; }

        public Guid IdProducto { get; set; }
        public required Producto Producto { get; set; }
    }
}
