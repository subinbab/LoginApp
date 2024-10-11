using UseCases.Response;

namespace UseCases.Register
{
  public interface IRegisterOperations
  {
    ResponseData<Core.AbstractModels.Register.Register> RegisterUser(Core.AbstractModels.Register.Register data);
  }
}