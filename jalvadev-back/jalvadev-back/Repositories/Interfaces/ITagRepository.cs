using jalvadev_back.Models;
using jalvadev_back.Utils;

namespace jalvadev_back.Repositories.Interfaces
{
    public interface ITagRepository
    {
        public Result<Tag> GetTagById(int id);

        public Result<List<Tag>> GetAllTags();
    }
}
