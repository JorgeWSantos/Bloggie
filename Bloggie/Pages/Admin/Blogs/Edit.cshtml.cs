using Bloggie.Data;
using Bloggie.Models.Domain;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        [BindProperty]
        public BlogPost blogPost { get; set; }

        public EditModel(BloggieDbContext _bloggieDbContext)
        {
            this.bloggieDbContext = _bloggieDbContext;
        }

        public async Task OnGet(Guid id)
        {
            blogPost = await this.bloggieDbContext.BlogPosts.FindAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            BlogPost blogPostExists = await this.bloggieDbContext.BlogPosts.FindAsync(blogPost.Id);

            if(blogPostExists != null)
            {
                blogPostExists.Heading = blogPost.Heading;
                blogPostExists.PageTitle = blogPost.PageTitle;
                blogPostExists.Content = blogPost.Content;
                blogPostExists.ShortDescription = blogPost.ShortDescription;
                blogPostExists.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                blogPostExists.UrlHandle = blogPost.UrlHandle;
                blogPostExists.PublishDate = blogPost.PublishDate;
                blogPostExists.Author = blogPost.Author;
                blogPostExists.Visible = blogPost.Visible;
            }

            await this.bloggieDbContext.SaveChangesAsync();

            return RedirectToPage("/Admin/Blogs/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            BlogPost blogPostExists = await this.bloggieDbContext.BlogPosts.FindAsync(blogPost.Id);

            if (blogPostExists != null)
            {
                this.bloggieDbContext.Remove(blogPostExists);
                await this.bloggieDbContext.SaveChangesAsync();
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
