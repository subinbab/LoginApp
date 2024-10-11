using Infrastructure.Register;
using Microsoft.AspNetCore.Mvc;
using UseCases.Register;

namespace LoginAPI.Controllers
{
  public class RegisterController : ControllerBase
  {
    private IRegisterOperations _register { get; set; }
    public RegisterController(IRegisterOperations register)
    {
          _register = register;
    }
    [HttpPost("Register")]
    public IActionResult RegisterUser(Core.AbstractModels.Register.Register user)
    {
      try
      {
        var result = _register.RegisterUser(user);
        if (result != null) {
          return Ok(result);
        }
        else
        {
          return BadRequest();
        }
      }
      catch (Exception ex) {
        return BadRequest(ex.Message);
      }
    }
  }
}
