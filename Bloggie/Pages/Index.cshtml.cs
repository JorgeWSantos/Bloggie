using Bloggie.Models.Domain;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostRepository blogPostRepository;


        public List<BlogPost> Blogs { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostRepository _blogPostRepository)
        {
            _logger = logger;
            this.blogPostRepository = _blogPostRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            this.Blogs = (await this.blogPostRepository.GetAllAsync()).ToList();
            return Page();
        }
    }
}
