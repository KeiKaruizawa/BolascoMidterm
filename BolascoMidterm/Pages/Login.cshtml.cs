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
                
                return RedirectToPage("/Index");
            }
            else
            {
               //
                ErrorMessage = "Invalid email or password. Please try again.";
                Username = string.Empty;
                Password = string.Empty;
                return Page();
            }
        }
    }
}