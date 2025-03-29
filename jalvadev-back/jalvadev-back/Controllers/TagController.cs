using jalvadev_back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jalvadev_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {

        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _tagService.GetAllTags();
            if(!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _tagService.GetTagById(id);
            if(!result.IsSuccess ) 
                return BadRequest(result);

            return Ok(result);
        }
    }
}
