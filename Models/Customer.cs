using System;
using System.Collections.Generic;

namespace SAOnlineMart.Models
{
    public class Customer
    {
        // Primary key for the Customer table in the database
        public int CustomerID { get; set; }

        // The name of the customer
        public string Name { get; set; }

        // The email address of the customer
        public string Email { get; set; }

        // The physical address of the customer
        public string Address { get; set; }

        // A customer can have multiple orders
        public List<Order> Orders { get; set; }
    }
}

