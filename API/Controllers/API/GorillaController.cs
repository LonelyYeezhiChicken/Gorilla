using API.Helper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GorillaController : ControllerBase
    {
        [HttpPost("todo")]
        public IActionResult ToDo([FromBody] string something)
        {
            try
            {
                string result = GorillaHelper.ToDo(something);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"猩猩腦袋壞掉了 {ex}");
            }
        }
    }
}
