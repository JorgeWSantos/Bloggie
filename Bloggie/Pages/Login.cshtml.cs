using Bloggie.Enum;
using Bloggie.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login loginModel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Microsoft.AspNetCore.Identity.SignInResult signResult = await
                signInManager.PasswordSignInAsync(
                    loginModel.Username, 
                    loginModel.Password, 
                    false, 
                    false
                );

            if(signResult.Succeeded)
            {
                return RedirectToPage("Index");
            }
            else
            {
                ViewData["Notification"] = new Notification
                {
                    type = NotificationType.Error,
                    message = "Unable to login"
                };

                return Page();
            }
        }
    }
}
