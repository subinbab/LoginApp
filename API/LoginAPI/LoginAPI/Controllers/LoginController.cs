using Core.AbstractModels.Login;
using LoginAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UseCases.Login;
using UseCases.Response;
using System.IdentityModel.Tokens.Jwt;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace LoginAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private ILoginOperations<ResponseData<UserLogin>> _loginOperations { get; set; }
    private UserManager<IdentityUser> _userManager { get; set; }
    private readonly ServiceConfiguration _appSettings;
    public LoginController(ILoginOperations<ResponseData<UserLogin>> loginOperations , UserManager<IdentityUser> userManager, IOptions<ServiceConfiguration> settings)
    {
          _loginOperations = loginOperations;
      _userManager = userManager;
      _appSettings = settings.Value;
    }
    [HttpPost("SignIn")]
    public IActionResult SignIn(UserLogin user)
    {
      try
      {
       var result =  _loginOperations.IsUserExist(user);
        if(result != null)
        {
          if (result.status)
          {
            ResponseModel<TokenModel> response = new ResponseModel<TokenModel>();
            try
            {
              AuthenticationResult authenticationResult = AuthenticateAsync(user).Result;
              if (authenticationResult != null && authenticationResult.Success)
              {
                response.username = user.Username;
                response.Data = new TokenModel() { Token = authenticationResult.Token, RefreshToken = authenticationResult.RefreshToken };
              }
              else
              {
                response.Message = "Something went wrong!";
                response.IsSuccess = false;
              }
            }
            catch
          { } 
              return Ok(response);
          }
          else
          {
            return BadRequest();
          }
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
    [NonAction]
    public async Task<AuthenticationResult> AuthenticateAsync(UserLogin user)
    {
      // authentication successful so generate jwt token
      AuthenticationResult authenticationResult = new AuthenticationResult();
      var tokenHandler = new JwtSecurityTokenHandler();

      try
      {
        var key = Encoding.ASCII.GetBytes(_appSettings.JwtSettings.Secret);

        ClaimsIdentity Subject = new ClaimsIdentity(new Claim[]
        {
                    new Claim("UserId", user.id.ToString()),
                    new Claim("FirstName", user.Username),
                    new Claim("LastName",user.Username),
                    new Claim("EmailId",user.Email==null?"":user.Email),
                    new Claim("UserName",user.Username==null?"":user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        });
        

        var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
        {
          Subject = Subject,
          Expires = DateTime.UtcNow.Add(_appSettings.JwtSettings.TokenLifetime),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        authenticationResult.Token = tokenHandler.WriteToken(token);
        var refreshToken = new RefreshToken
        {
          Token = Guid.NewGuid().ToString(),
          jwtId = token.Id,
          userId = user.id.ToString(),
          creatiomDate = DateTime.UtcNow,
          ExpiryDate = DateTime.UtcNow.AddMonths(6)
        };
        authenticationResult.RefreshToken = refreshToken.Token;
        authenticationResult.Success = true;
        return authenticationResult;
      }
      catch (Exception ex)
      {
        return null;
      }

    }
  }
}

