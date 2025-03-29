using jalvadev_back.Models;
using jalvadev_back.Utils;

namespace jalvadev_back.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        public Result<Project> GetProjectById(int id);

        public Result<List<Project>> GetAllProjects();
    }
}
