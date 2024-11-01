using Bloggie.Data;
using Bloggie.Models.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        public List<BlogPost> blogPosts { get; set; }

        public ListModel(BloggieDbContext _bloggieDbContext)
        {
            this.bloggieDbContext = _bloggieDbContext;
        }

        public async Task OnGet()
        {
            blogPosts = await this.bloggieDbContext.BlogPosts.ToListAsync();
        }
    }
}
