using API.Helper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GorillaController : ControllerBase
    {
        private readonly ILogger<GorillaController> _logger;

        public GorillaController(ILogger<GorillaController> logger)
        {
            _logger = logger;
        }

        [HttpPost("todo")]
        public IActionResult ToDo([FromBody] string something)
        {
            try
            {
                _logger.LogInformation($"inpute:{something}");
                string result = GorillaHelper.ToDo(something);
                _logger.LogInformation($"output{result}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"猩猩腦袋壞掉了 {ex}");
            }
        }
    }
}
