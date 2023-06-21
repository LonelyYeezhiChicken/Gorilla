using API.Helper;
using API.SDK;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GorillaController : ControllerBase
    {
        private readonly ILogger<GorillaController> _logger;
        private readonly IChatGpt _chatGpt;

        public GorillaController(ILogger<GorillaController> logger, IChatGpt chatGpt)
        {
            _logger = logger;
            _chatGpt = chatGpt;
        }

        [HttpPost("todo")]
        public async Task<IActionResult> ToDo([FromBody] string something)
        {
            try
            {
                _logger.LogInformation($"inpute:{something}");
                string result = await GorillaHelper.ToDo(something, _chatGpt);
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
