namespace Infrastructure.Register
{
  using Core.AbstractModels.Register;
  using Microsoft.EntityFrameworkCore.ChangeTracking;
  using UseCases.Response;

  public interface IRegister
  {
    ResponseData<EntityEntry<Core.AbstractModels.Register.Register>> RegisterUser(Register register);
  }
}
