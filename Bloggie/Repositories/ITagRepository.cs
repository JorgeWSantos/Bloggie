using Bloggie.Models.Domain;

namespace Bloggie.Repositories
{
    public interface ITagRepository
    {
        public Task<IEnumerable<Tag>> GetAllAsync();
    }
}
