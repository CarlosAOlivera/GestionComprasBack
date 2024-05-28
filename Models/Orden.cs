using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LionDev.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public string CustomerFirstName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        [Required, Range(0, double.MaxValue)]
        public decimal Subtotal { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Tax { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Total { get; set; }

        public decimal DeliveryCost { get; set; }
        public string DeliveryInfo { get; set; } = string.Empty;
        public List<OrdenItem> OrdenItems { get; set; } = new List<OrdenItem>();

        [Required]
        public DateTime EstimatedDeliveryDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }

public class OrdenItem
    {
        public int OrdenItemId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
