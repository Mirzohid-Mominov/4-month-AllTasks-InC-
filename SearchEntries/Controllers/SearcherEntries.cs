using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchEntries.Services;

namespace SearchEntries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearcherEntries : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] Searching searching, string fileName)
        {
            return Ok(searching.SearchDirectoryName(fileName));
        }
    }
}
