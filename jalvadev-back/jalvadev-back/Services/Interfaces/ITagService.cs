using jalvadev_back.DTOs;
using jalvadev_back.Utils;

namespace jalvadev_back.Services.Interfaces
{
    public interface ITagService
    {
        public Result<TagDTO> GetTagById(int id);

        public Result<List<TagDTO>> GetAllTags();
    }
}
