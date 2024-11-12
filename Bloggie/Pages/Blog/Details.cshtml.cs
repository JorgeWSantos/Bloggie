using Bloggie.Models.Domain;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages.Blogs
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;
        public BlogPost blogPost { get; set; }

        public DetailsModel(IBlogPostRepository _blogPostRepository)
        {
            this.blogPostRepository = _blogPostRepository;
        }
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            blogPost = await this.blogPostRepository.GetAsyncByUrlHandle(urlHandle);
            return Page();
        }
    }
}
