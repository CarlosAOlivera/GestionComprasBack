namespace LionDev.Models
{
    public class Marca
    {
        public Guid IdMarca { get; set; }
        public required string Nombre { get; set; }

        public ICollection<Producto>? Producto { get; set; }
    }
}
