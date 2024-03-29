namespace LionDev.Models
{
    public class Color
    {
        public Guid IdColor { get; set; }
        public string Nombre { get; set; }

        // Relación con ProductoColor
        public ICollection<ProductoColor> ProductoColores { get; set; }
    }
}
