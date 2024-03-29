namespace LionDev.Models
{
    public class Talla
    {
        public Guid IdTalla { get; set; }
        public string Nombre { get; set; }

        // Relación con ProductoTalla
        public ICollection<ProductoTalla> ProductoTallas { get; set; }
    }
}

