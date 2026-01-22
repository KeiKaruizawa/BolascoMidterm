using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BolascoMidterm.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        private const string validUsername = "hello@gmail.com";
        private const string validPassword = "helloworld";

        public void OnGet()
        {
            ErrorMessage = string.Empty;
        }

        public IActionResult OnPost()
        {
            if (Username == validUsername && Password == validPassword)
            {
                // Successful login - success message and redirect
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
    }
}