using jalvadev_back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jalvadev_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _projectService.GetAllProjects();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _projectService.GetProjectById(id);
            if(!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
