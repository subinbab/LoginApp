using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractModels.Login
{
  public class UserLogin : UserLoginBase
  {
    public string? Email { get; set; }

    public override bool ValidateCredentials()
    {
      // Implement credential validation logic (e.g., check against a database)
      if (!ValidatePassword(Password))
      {
        return false;
      }

      // Example: Simulate credential check
      // In a real application, you would query your user database
      return Username == "testUser" && Password == "testPassword"; // Replace with actual logic
    }
  }

}
