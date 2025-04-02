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

        [HttpGet("list/{page}")]
        public IActionResult List(int page)
        {
            var postListResult = _postService.GetPostByPage(1, page);
            if(!postListResult.IsSuccess)
                return BadRequest(postListResult);

            return Ok(postListResult);
        }
    }
}
