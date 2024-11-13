using Bloggie.Models.Domain;

namespace Bloggie.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<IEnumerable<BlogPost>> GetAllAsyncByTagName(string tagName);
        Task<BlogPost> GetAsync(Guid id);
        Task<BlogPost> GetAsyncByUrlHandle(string urlHandle);
        Task<BlogPost> AddAsync(BlogPost blogPost);
        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task<bool> DeleteAsync(Guid id);
    }
}
