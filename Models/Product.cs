using System.Collections.Generic;

namespace SAOnlineMart.Models
{
    // Represents a product in the online store.
    public class Product
    {
        // Primary key for the product. Uniquely identifies each product.
        public int ProductID { get; set; }

        // Name of the product.
        public string Name { get; set; }

        // Description of the product.
        public string Description { get; set; }

        // Price of the product. Should be a positive value.
        public decimal Price { get; set; }

        // Category under which the product is listed.
        public string Category { get; set; }

        // Represents a collection of OrderItem objects associated with this product.
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
