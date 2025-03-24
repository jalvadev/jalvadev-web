using jalvadev_back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jalvadev_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userResult = _userService.GetUserById(1);
            if(!userResult.IsSuccess)
                return BadRequest(userResult);

            return Ok(userResult);
        }
    }
}
