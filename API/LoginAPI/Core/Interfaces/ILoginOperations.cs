using Core.AbstractModels.Login;
using UseCases.Response;

namespace UseCases.Login
{
  public interface ILoginOperations<T>
  {
    T IsUserExist(UserLogin user);
    T RecordLogin(UserLogin user);
  }
}
