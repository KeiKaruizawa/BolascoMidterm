using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BolascoMidterm.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;
        public string SuccessMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;
        }

        public IActionResult OnPost()
        {
            // Validate email format using regex
            if (!IsValidEmail(Email))
            {
                ErrorMessage = "Please enter a valid email address (e.g., user@example.com)";
                ModelState.Clear();
                Email = string.Empty;
                Password = string.Empty;
                ConfirmPassword = string.Empty;
                return Page();
            }

            // Validate passwords match
            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match. Please try again.";
                ModelState.Clear();
                Password = string.Empty;
                ConfirmPassword = string.Empty;
                return Page();
            }

            // Validate password length
            if (Password.Length < 6)
            {
                ErrorMessage = "Password must be at least 6 characters long.";
                ModelState.Clear();
                Password = string.Empty;
                ConfirmPassword = string.Empty;
                return Page();
            }

            // Registration successful
            SuccessMessage = "Account created successfully! Redirecting to login...";

            // Redirect to login page after 2 seconds
            Response.Headers.Add("Refresh", "2; url=/Login");
            return Page();
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex pattern for valid email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}