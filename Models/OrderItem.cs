namespace SAOnlineMart.Models
{
    // Represents an item in an order, linking an order with a product and specifying the quantity and unit price.
    public class OrderItem
    {
        // Primary key for the OrderItem entity.
        public int OrderItemID { get; set; }

        // Foreign key to the Order entity.
        public int OrderID { get; set; }

        // Navigation property for the related Order entity.
        public Order Order { get; set; }

        // Foreign key to the Product entity.
        public int ProductID { get; set; }

        // Navigation property for the related Product entity.
        public Product Product { get; set; }

        // Quantity of the product in the order.
        public int Quantity { get; set; }

        // Price per unit of the product at the time of the order.
        public decimal UnitPrice { get; set; }
    }
}
