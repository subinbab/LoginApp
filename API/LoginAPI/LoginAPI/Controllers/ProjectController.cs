using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseCases.UseCases.ProjectOperation;

namespace LoginAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectController : ControllerBase
  {
    private IUseCasesProjectOperations _operations { get; set; }
    public ProjectController(IUseCasesProjectOperations operations)
    {
        _operations = operations;
    }
    [HttpGet("CreateProject")]
    public IActionResult CreateProject()
    {
      _operations.CreateProject(new Core.AbstractModels.Project.ProjectModel());
      return Ok();
    }
  }
}
