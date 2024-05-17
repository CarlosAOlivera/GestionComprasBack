namespace LionDev.Models
{
    public class Orden
    {
        public Customer { get; set; }
        public int OrdenId { get; set; }
        public List<OrdenItem> OrdenItems { get; set; } = new List<OrdenItem>();
        public decimal Total { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
    }

    public class Customer
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        // Otras propiedades del cliente...
    }

public class OrdenItem
    {
        public int Quantity { get; set; }
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
