using Core.AbstractModels.Login;

namespace Infrastructure.Login
{
  public interface ILogin
  {
    UserLogin CheckUserIn(UserLogin user);
    UserLogin RecordLoginData(UserLogin user);
  }
}
