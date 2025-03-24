using jalvadev_back.Models;
using jalvadev_back.Utils;

namespace jalvadev_back.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Result<User> GetUserById(int id);
    }
}
