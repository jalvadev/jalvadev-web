using jalvadev_back.Resources;
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
        public IActionResult List(int page, string? categories = null)
        {
            List<int> categoryIds = null;

            if (categories != null)
            {
                categoryIds = categories
                    .Replace("[", "")
                    .Replace("]", "")
                    .Split(",")
                    .Where(c => int.TryParse(c, out _))
                    .Select(c => int.Parse(c)).ToList();

                if (!categories.StartsWith('[') || !categories.EndsWith(']') || categoryIds == null || categoryIds.Count() == 0)
                    return BadRequest(Resource.ui_error_category_filter_match);
            }
            
            var postListResult = _postService.GetPostByPage(1, page, categoryIds);
            if(!postListResult.IsSuccess)
                return BadRequest(postListResult);

            return Ok(postListResult);
        }
    }
}
