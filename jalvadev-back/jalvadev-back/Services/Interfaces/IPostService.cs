using jalvadev_back.DTOs;
using jalvadev_back.Utils;

namespace jalvadev_back.Services.Interfaces
{
    public interface IPostService
    {
        Result<PostDetailDTO> GetPostDetail(int id);
    }
}
