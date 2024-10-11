using Core.AbstractModels.Login;
using Infrastructure.Login;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Response;

namespace UseCases.Login
{
  public class LoginOperations : ILoginOperations<ResponseData<UserLogin>>
  {
    private ILogin _loginOperations { get; set; }
    private UserManager<IdentityUser> _userManager { get; set; }
    public LoginOperations(ILogin loginOperation,UserManager<IdentityUser> userManager )
    {
      _loginOperations = loginOperation;
      _userManager = userManager;
    }
    public ResponseData<UserLogin> IsUserExist(UserLogin user )
    {
    
      var checkLogin = _userManager.FindByEmailAsync(user.Username).Result;
      if (checkLogin != null)
      {
        var result = new ResponseData<UserLogin>();
        result.response = user;
        result.status = true;
        result.message = $"user is able to login succesfully";
        RecordLogin(user);
        return result;
      }
      else
      {
        return null;
      }
      
    }
    public ResponseData<UserLogin> RecordLogin(UserLogin user)
    {
      try
      {
        user.LoginDate = DateTime.Now;
        if (_loginOperations.RecordLoginData(user) != null)
        {
          return new ResponseData<UserLogin> { status =true,response =user , message="succesfully logged in and recorded"};
        };
        return new ResponseData<UserLogin> { status = false, response = null, message = "not able to login " };
      }
      catch
      {
        return new ResponseData<UserLogin> { status = false, response = null, message = "not able to login " };
      }
    }
  }
}
