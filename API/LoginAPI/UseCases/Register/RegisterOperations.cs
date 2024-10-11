using Core.AbstractModels.User;
using Infrastructure.Register;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UseCases.Response;

namespace UseCases.Register
{
  public class RegisterOperations : IRegisterOperations
  {
    private IRegisterUser _register { get; set; }
    private UserManager<IdentityUser> _userManager { get; set; }
    public RegisterOperations(IRegisterUser register, UserManager<IdentityUser> userManager)
    {
      _register = register;
      _userManager = userManager;
    }

    public ResponseData<Core.AbstractModels.Register.Register> RegisterUser(Core.AbstractModels.Register.Register data)
    {
      try
      {
        var returnData = new ResponseData<Core.AbstractModels.Register.Register>();
        var user = new IdentityUser { UserName = data.username, Email = data.username};
        //var result = _register.RegisterUser(data);
        var result = _userManager.CreateAsync(user,data.password).Result;
        if (result != null)
        {

          returnData.status = true;
          returnData.error = "";
          return returnData;
        }
        else
        {
          return null;
        }

      }
      catch
      {
        return null;
      }
    }
  }
}
