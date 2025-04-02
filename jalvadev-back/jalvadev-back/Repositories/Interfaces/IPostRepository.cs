using jalvadev_back.Models;
using jalvadev_back.Utils;

namespace jalvadev_back.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Result<Post> GetPostById(int postId);

        Result<List<Post>> GetPostByUser(int userId, int limit, int offset);

        Result<int> GetNumberOfPages(int user, int limit);
    }
}
