using jalvadev_back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jalvadev_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {

        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            var postResult = _postService.GetPostDetail(id);
            if(!postResult.IsSuccess)
                return BadRequest(postResult);

            return Ok(postResult);
        }
    }
}
