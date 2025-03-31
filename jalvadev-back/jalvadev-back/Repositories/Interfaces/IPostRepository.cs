using jalvadev_back.Models;
using jalvadev_back.Utils;

namespace jalvadev_back.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Result<Post> GetPostById(int postId);
    }
}
