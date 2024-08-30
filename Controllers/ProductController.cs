using Microsoft.AspNetCore.Mvc; 
using SAOnlineMart.Models; 
using System.Linq; 

namespace SAOnlineMart.Controllers
{
    // This controller handles product-related actions
    public class ProductController : Controller
    {
        // Dependency of the application's database context
        private readonly SAOnlineMartContext _context;

        // Constructor that initializes the context
        public ProductController(SAOnlineMartContext context)
        {
            _context = context; // Assigns the injected context to the private field
        }

        
        // This action method retrieves all products from the database and displays them on the index page
        public IActionResult Index()
        {
            var products = _context.Products.ToList(); 
            return View(products); 
        }
    }
}


