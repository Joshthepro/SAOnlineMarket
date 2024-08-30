using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; 
using SAOnlineMart.Models; 
using System.Linq; 

namespace SAOnlineMart.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly SAOnlineMartContext _context; // Database context for accessing data

        // Constructor to initialize the database context
        public OrderItemController(SAOnlineMartContext context)
        {
            _context = context;
        }

       
        public IActionResult Index(int orderId)
        {
            // Query the OrderItems table to find items matching the given orderId
            // Include related Product information to avoid lazy loading
            var orderItems = _context.OrderItems
                .Where(oi => oi.OrderID == orderId) // Filter by OrderID
                .Include(oi => oi.Product) // Include Product details in the result
                .ToList(); // Convert the result to a list

            return View(orderItems);
        }
    }
}

