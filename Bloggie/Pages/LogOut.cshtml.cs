using Bloggie.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LogOutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("Index");
        }
    }
}
