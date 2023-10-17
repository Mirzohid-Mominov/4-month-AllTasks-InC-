using Microsoft.AspNetCore.Mvc;
using N53_HT1.Models;
using N53_HT1.Services;

namespace N53_HT1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BonusesController : ControllerBase
    {
        private readonly BonusService _bonusService;

        public BonusesController(BonusService bonusService)
        {
            _bonusService = bonusService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _bonusService.Get(bonus => true);
            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create(Bonus bonus)
        {
            var result = await _bonusService.CreateAsync(bonus);
            return Ok(result);
        }
    }
}
