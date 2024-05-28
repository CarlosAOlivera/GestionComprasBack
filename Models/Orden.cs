using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LionDev.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Subtotal { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Tax { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Total { get; set; }

        public decimal DeliveryCost { get; set; }
        public string DeliveryInfo { get; set; }
        public List<OrdenItem> OrdenItems { get; set; }

        [Required]
        public DateTime EstimatedDeliveryDate { get; set; }
    }

public class OrdenItem
    {
        public int OrdenItemId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
