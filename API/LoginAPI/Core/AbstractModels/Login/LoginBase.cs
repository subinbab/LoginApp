using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractModels.Login
{
  public abstract class UserLoginBase
  {
    public Guid id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime LoginDate { get; set; }

    public abstract bool ValidateCredentials();

    protected bool ValidatePassword(string password)
    {
      // Implement password validation logic (e.g., length, complexity)
      return !string.IsNullOrEmpty(password) && password.Length >= 6;
    }
  }

}
