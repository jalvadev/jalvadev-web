using AutoMapper;
using jalvadev_back.DTOs;
using jalvadev_back.Models;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Services.Interfaces;
using jalvadev_back.Utils;

namespace jalvadev_back.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Result<List<ProjectDTO>> GetAllProjectsByUserId(int userId)
        {
            var result = _repository.GetAllProjectsByUserId(userId);
            if (!result.IsSuccess)
                return Result<List<ProjectDTO>>.Failure(result.Message);

            List<ProjectDTO> projects = _mapper.Map<List<Project>, List<ProjectDTO>>(result.Value);

            return Result<List<ProjectDTO>>.Success(projects);
        }

        public Result<ProjectDTO> GetProjectById(int id)
        {
            var result = _repository.GetProjectById(id);
            if (!result.IsSuccess)
                return Result<ProjectDTO>.Failure(result.Message);

            ProjectDTO project = _mapper.Map<ProjectDTO>(result.Value);

            return Result<ProjectDTO>.Success(project);
        }
    }
}
