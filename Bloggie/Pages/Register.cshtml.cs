using Bloggie.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]  
        public Register registerViewModel { get; set; }
        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = this.registerViewModel.Username,
                Email = this.registerViewModel.Email,
            };

            var identityResult = await this.userManager.CreateAsync(user, this.registerViewModel.Password);

            if(identityResult.Succeeded)
            {
                ViewData["Notification"] = new Notification
                {
                    type = Enum.NotificationType.Sucess,
                    message = "User registered sucessfully"
                };

                return Page();
            }

            ViewData["Notification"] = new Notification
            {
                type = Enum.NotificationType.Error,
                message = "Something went wrong"
            };

            return Page();
        }
    }
}
