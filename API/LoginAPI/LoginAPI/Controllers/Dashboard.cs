
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace LoginAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class Dashboard : ControllerBase
  {
    public Dashboard()
    {
          
    }
    [Microsoft.AspNetCore.Mvc.HttpGet("GetService")]
    public IActionResult GetService()
    {
      return Ok();
    }
  }
}
