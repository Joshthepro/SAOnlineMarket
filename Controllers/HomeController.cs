using Microsoft.AspNetCore.Mvc; 
using SAOnlineMart.Models; 
using System.Diagnostics; 

namespace SAOnlineMart.Controllers
{
    // The HomeController handles requests related to the home page and general site information.
    public class HomeController : Controller
    {
        // Dependency injection for the ILogger service to log information, warnings, and errors.
        private readonly ILogger<HomeController> _logger;

        // Constructor that initializes the logger service.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method for the homepage ("/Home/Index"). Renders the Index view.
        public IActionResult Index()
        {
            return View(); 
        }

       
        public IActionResult Privacy()
        {
            return View(); // Returns the "Privacy" view to the user.
        }

        // Action method for handling errors. It is configured not to cache any response.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Returns the "Error" view with an ErrorViewModel containing the current request ID.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}