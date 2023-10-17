using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class TestController : ControllerBase
    {
        [HttpGet("singleton")]
        public IActionResult Get([FromServices] SingletonService singletonService)
        {
            return Ok(singletonService.ID);
        }
        
        [HttpGet("scoped")]
        public IActionResult Get([FromServices] ScopedService scopedService)
        {
            return Ok(scopedService);
        }
        
        [HttpGet("transient")]
        public IActionResult Get([FromServices] TransientService transientService)
        {
            return Ok(transientService);
        }

    }
}
