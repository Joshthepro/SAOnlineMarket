using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAOnlineMart.Models;
using System.Linq;

namespace SAOnlineMart.Controllers
{
    // Controller for handling order-related actions
    public class OrderController : Controller
    {
        // Reference to the database context
        private readonly SAOnlineMartContext _context;

        // Constructor that initializes the controller with the database context
        public OrderController(SAOnlineMartContext context)
        {
            _context = context;
        }

        // GET: Order
        // Action to display a list of all orders
        public IActionResult Index()
        {
            // Fetch all orders from the database, including related Customer data
            var orders = _context.Orders.Include(o => o.Customer).ToList();

            // Pass the list of orders to the view for display
            return View(orders);
        }

    }
}

