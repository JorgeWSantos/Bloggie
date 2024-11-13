using Bloggie.Data;
using Bloggie.Models.Domain;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages.Tags
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public List<BlogPost> blogs { get; set; }

        public DetailsModel(IBlogPostRepository _blogPostRepository)
        {
            this.blogPostRepository = _blogPostRepository;
        }
        public async Task<IActionResult> OnGet(string tagName)
        {
            this.blogs = (await this.blogPostRepository.GetAllAsyncByTagName(tagName)).ToList();

            return Page();
        }
    }
}
