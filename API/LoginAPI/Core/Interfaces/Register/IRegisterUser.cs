using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Register
{
  public interface IRegisterUser
  {
    EntityEntry<Core.AbstractModels.Register.Register> RegisterUser(Core.AbstractModels.Register.Register register);
  }
}