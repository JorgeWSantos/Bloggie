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
        private readonly ITagRepository tagRepository;

        public List<BlogPost> blogs { get; set; }
        public List<Tag> tags { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger, 
            IBlogPostRepository _blogPostRepository,
            ITagRepository _tagRepository)
        {
            _logger = logger;
            this.blogPostRepository = _blogPostRepository;
            tagRepository = _tagRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            this.blogs = (await this.blogPostRepository.GetAllAsync()).ToList();
            this.tags = (await this.tagRepository.GetAllAsync()).ToList();
            return Page();
        }
    }
}
