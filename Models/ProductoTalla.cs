namespace LionDev.Models
{
    public class ProductoTalla
    {
        public Guid IdProducto { get; set; }
        public Producto Producto { get; set; }

        public Guid IdTalla { get; set; }
        public Talla Talla { get; set; }
    }
}
