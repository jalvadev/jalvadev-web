using jalvadev_back.DTOs;
using jalvadev_back.Utils;

namespace jalvadev_back.Services.Interfaces
{
    public interface IProjectService
    {
        public Result<ProjectDTO> GetProjectById(int id);
    }
}
