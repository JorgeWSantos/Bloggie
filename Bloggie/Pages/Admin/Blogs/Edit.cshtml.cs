using Bloggie.Data;
using Bloggie.Enum;
using Bloggie.Models.Domain;
using Bloggie.Models.ViewModels;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost blogPost { get; set; }

        [BindProperty]
        public string tags { get; set; }

        public EditModel(IBlogPostRepository _blogPostRepository)
        {
            this.blogPostRepository = _blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            blogPost = await this.blogPostRepository.GetAsync(id);

            if (blogPost.tags != null && blogPost.tags != null)
            {
                tags = string.Join(',', blogPost.tags.Select(x => x.Name));
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                blogPost.tags = new List<Tag>(tags.Split(',')
                                    .Select(x => new Tag() { Name = x.Trim() }));

                await this.blogPostRepository.UpdateAsync(blogPost);

                ViewData["MessageDescription"] = "Save was successfully saved!";

                ViewData["Notification"] = new Notification()
                {
                    message = "Record updated successfully",
                    type = NotificationType.Sucess
                };
            }
            catch (Exception)
            {
                ViewData["Notification"] = new Notification()
                {
                    message = "Something went wrong!",
                    type = NotificationType.Error
                };
            }

            return Page();

        }

        public async Task<IActionResult> OnPostDelete()
        {
            Boolean isDeleted = await this.blogPostRepository.DeleteAsync(blogPost.Id);

            if (isDeleted)
            {
                Notification notification = new Notification
                {
                    type = Enum.NotificationType.Sucess,
                    message = "Blog deleted successfully!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
