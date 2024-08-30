using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineMart.Models
{
    
    public class ErrorView
    {
        // The error message to be displayed. This field is required and cannot exceed 200 characters.
        [Required]
        [StringLength(200, ErrorMessage = "Error message cannot exceed 200 characters.")]
        public string ErrorMessage { get; set; }

        // The HTTP status code associated with the error. Valid range is between 100 and 599.
        [Range(100, 599, ErrorMessage = "Error code must be between 100 and 599.")]
        public int ErrorCode { get; set; }

        // Additional details about the error. This field cannot exceed 1000 characters.
        [StringLength(1000, ErrorMessage = "Details cannot exceed 1000 characters.")]
        public string Details { get; set; }

        
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

    // Example controller action to handle errors.
    public class ErrorController : Controller
    {
        // Action method to return the error view with a predefined error message and details.
        public IActionResult Error()
        {
            // An instance of ErrorView with sample error data.
            var errorView = new ErrorView
            {
                ErrorMessage = "An unexpected error occurred.",
                ErrorCode = 500,
                Details = "Error details here."
            };

            // Return the view with the errorView model.
            return View(errorView);
        }
    }
}


