using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc; 
using SAOnlineMart.Models; 
using System.Linq; // Import LINQ for querying collections

namespace SAOnlineMart.Controllers
{
    [Authorize] // Ensure only authorized users can access this controller
    public class AdminController : Controller
    {
        private readonly SAOnlineMartContext _context; 

        // Constructor to inject the database context (Dependency Injection)
        public AdminController(SAOnlineMartContext context)
        {
            _context = context;
        }

        // GET: /Admin/Index
        public IActionResult Index()
        {
            // Fetch all products from the database and pass them to the view
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: /Admin/Create
        public IActionResult Create()
        {
            // Display the form to create a new product
            return View();
        }

        // POST: /Admin/Create
        [HttpPost] // Indicate that this action responds to POST requests
        public IActionResult Create(Product product)
        {
            
            if (ModelState.IsValid)
            {
                // Add the new product to the database
                _context.Products.Add(product);
                _context.SaveChanges(); 
                return RedirectToAction("Index"); 
            }
            // If the model is invalid, redisplay the form with validation messages
            return View(product);
        }

        
        public IActionResult Edit(int id)
        {
            // Find the product by its ID
            var product = _context.Products.Find(id);
            if (product == null) return NotFound(); // Return 404 if the product doesn't exist
            return View(product); // Pass the found product to the view for editing
        }

        // POST: /Admin/Edit
        [HttpPost] // Indicate that this action responds to POST requests
        public IActionResult Edit(Product product)
        {
            // Check if the submitted model is valid
            if (ModelState.IsValid)
            {
                // Update the product in the database
                _context.Products.Update(product);
                _context.SaveChanges(); 
                return RedirectToAction("Index"); 
            }
            // If the model is invalid, redisplay the form with validation messages
            return View(product);
        }

       
        public IActionResult Delete(int id)
        {
            
            var product = _context.Products.Find(id);
            if (product == null) return NotFound(); // Return 404 if the product doesn't exist
            return View(product); // Pass the found product to the view for deletion confirmation
        }

        
        [HttpPost, ActionName("Delete")] // this action responds to POST requests and maps to "Delete" action
        public IActionResult DeleteConfirmed(int id)
        {
            // Find the product by its ID again for confirmation
            var product = _context.Products.Find(id);
            if (product == null) return NotFound(); 
            _context.Products.Remove(product); 
            _context.SaveChanges(); 
            return RedirectToAction("Index"); 
        }
    }
}

