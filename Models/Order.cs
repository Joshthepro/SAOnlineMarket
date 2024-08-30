using System;
using System.Collections.Generic;

namespace SAOnlineMart.Models
{
    public class Order
    {
        // Primary key for the Order table.
        public int OrderID { get; set; }

        // The date and time when the order was placed.
        public DateTime OrderDate { get; set; }

        // The total amount of the order.
        public decimal TotalAmount { get; set; }

        // Foreign key for the associated customer.
        public int CustomerID { get; set; }

        // Navigation property to the Customer who placed the order.
        public Customer Customer { get; set; }

        // Navigation property for the items included in the order.
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

