namespace LionDev.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public ICollection<OrdenItem> OrdenItems { get; set; }
    }

    public class Customer
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        // Otras propiedades del cliente...
    }

public class OrdenItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
