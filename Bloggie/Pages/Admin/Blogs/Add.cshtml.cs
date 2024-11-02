using Bloggie.Data;
using Bloggie.Models.Domain;
using Bloggie.Models.ViewModels;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        public readonly IBlogPostRepository blogPostRepository;
        
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }


        public AddModel(IBlogPostRepository _blogPostRepository)
        {
            this.blogPostRepository = _blogPostRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishDate = AddBlogPostRequest.PublishDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
            };

            await this.blogPostRepository.AddAsync(blogPost);

            Notification notification = new Notification
            {
                type = Enum.NotificationType.Sucess,
                message = "New blog created!"
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
