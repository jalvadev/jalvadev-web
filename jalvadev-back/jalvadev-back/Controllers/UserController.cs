using jalvadev_back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jalvadev_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("HOllaaaaa");
            var userResult = _userService.GetUserById(1);
            if(!userResult.IsSuccess)
                return BadRequest(userResult);

            return Ok(userResult);
        }
    }
}
