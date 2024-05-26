namespace LionDev.Models
{
    public class ProductoColor
    {
        public Guid IdProducto { get; set; }
        public Producto Producto { get; set; }

        public Guid IdColor { get; set; }
        public Color Color { get; set; }
    }
}
