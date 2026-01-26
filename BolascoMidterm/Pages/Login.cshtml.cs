using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BolascoMidterm.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        private const string validUsername = "hello@gmail.com";
        private const string validPassword = "helloworld";

        public void OnGet()
        {
            ErrorMessage = string.Empty;
        }

        public IActionResult OnPost()
        {
            // Validate email format
            if (!IsValidEmail(Username))
            {
                ErrorMessage = "Please enter a valid email address (e.g., user@example.com)";
                ModelState.Clear();
                Username = string.Empty;
                Password = string.Empty;
                return Page();
            }

            if (Username == validUsername && Password == validPassword)
            {
                // Successful login - redirect
                return RedirectToPage("/Index");
            }
            else
            {
                // Failed login - clear inputs, show error
                ErrorMessage = "Invalid email or password. Please try again.";
                ModelState.Clear(); // clears the form state
                Username = string.Empty;
                Password = string.Empty;
                return Page();
            }
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