using Bloggie.Data;
using Bloggie.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggieDbContext bloggieDbContext;
        public BlogPostRepository(BloggieDbContext _bloggieDbContext)
        {
            this.bloggieDbContext = _bloggieDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await this.bloggieDbContext.BlogPosts.AddAsync(blogPost);
            await this.bloggieDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            BlogPost blogPostExists = await this.bloggieDbContext.BlogPosts.FindAsync(id);

            if (blogPostExists != null)
            {
                this.bloggieDbContext.Remove(blogPostExists);
                await this.bloggieDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await this.bloggieDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await this.bloggieDbContext.BlogPosts.FindAsync(id);
        }

        public async Task<BlogPost> GetAsyncByUrlHandle(string urlHandle)
        {
            return await this.bloggieDbContext.BlogPosts.FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            BlogPost blogPostExists = await this.bloggieDbContext.BlogPosts.FindAsync(blogPost.Id);

            if (blogPostExists != null)
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

            return blogPostExists;
        }
    }
}
