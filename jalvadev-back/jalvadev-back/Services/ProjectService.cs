using AutoMapper;
using jalvadev_back.DTOs;
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
