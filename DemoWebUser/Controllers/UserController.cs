using DemoWebUser.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create(UserForCreation userForCreation)
        {
            var result = _userService.Create(userForCreation);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var foundUser = _userService.Get(id);
            return Ok(foundUser);
        }
    }
}
