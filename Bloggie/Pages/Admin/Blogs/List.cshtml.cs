using Bloggie.Data;
using Bloggie.Models.Domain;
using Bloggie.Models.ViewModels;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Bloggie.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogPost> blogPosts { get; set; }

        public ListModel(IBlogPostRepository _blogPostRepository)
        {
            this.blogPostRepository = _blogPostRepository;
        }

        public async Task OnGet()
        {
            string notificationJson = (string)TempData["Notification"];

            if(!string.IsNullOrEmpty(notificationJson))
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }

            blogPosts = (await this.blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
