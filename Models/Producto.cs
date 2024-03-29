namespace LionDev.Models
{
    public class Producto
    {
        public Guid IdProducto { get; set; } 

        public required string  Nombre { get; set;}
        public required string Referencia { get; set; }
        public string? UrlImagen { get; set; }
        public string? Descripcion { get; set; }
        public string? Color { get; set; }
        public required int Cantidad { get; set; }
        public required string Talla { get; set; }
        public required int Valor { get; set; }
        public required bool EsDeLosMasBuscados { get; set; }
        public required string ParaSexo { get; set; }

        public Guid IdMarca { get; set; }
        public Marca Marca { get; set; } = new Marca() { Nombre = "ValorPredeterminado" };

        //public required ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
