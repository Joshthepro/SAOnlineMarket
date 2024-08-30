using Microsoft.AspNetCore.Mvc;
using SAOnlineMart.Models;
using System.Linq;

namespace SAOnlineMart.Controllers
{
    // Controller to manage Customer operations like Create, Read, Update, and Delete (CRUD, Class)
    public class CustomerController : Controller
    {
        private readonly SAOnlineMartContext _context;

        
        public CustomerController(SAOnlineMartContext context) // Constructor to initialize the database context
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Retrieve all customers from the database and convert to a list
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // Action to display the Create Customer form
        public IActionResult Create()
        {
            
            return View();
        }

        // Action to handle the form submission for creating a new customer
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            // Check if the submitted customer data is valid
            if (ModelState.IsValid)
            {
                // Add the new customer to the context
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            // If the model state is invalid, redisplay the form with validation errors
            return View(customer);
        }

        // Action to display the Edit Customer form for a specific customer
        public IActionResult Edit(int id)
        {
            
            var customer = _context.Customers.Find(id);
            // If no customer is found, return a 404 Not Found response
            if (customer == null) return NotFound();
            return View(customer);
        }

        // Action to handle the form submission for editing an existing customer
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            // Check if the submitted customer data is valid
            if (ModelState.IsValid)
            {
                
                _context.Customers.Update(customer);
                _context.SaveChanges(); 
                return RedirectToAction("Index");
            }
            // If the model state is invalid, redisplay the form with validation errors
            return View(customer);
        }

        // Action to display the Delete Customer confirmation page for a specific customer
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            // Pass the customer data to the view for confirmation of deletion
            return View(customer);
        }

        // Action to handle the confirmation of customer deletion
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Find the customer in the database using the provided ID
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
