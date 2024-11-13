using Bloggie.Data;
using Bloggie.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public TagRepository(BloggieDbContext _bloggieDbContext)
        {
            this.bloggieDbContext = _bloggieDbContext;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            List<Tag> tags = await this.bloggieDbContext.Tags.ToListAsync();

            return tags.DistinctBy(x => x.Name.ToLower()); ;
        }
    }
}
