using Core.AbstractModels.Login;
using Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Login
{
  public class Login : ILogin
  {
    private AppDbContext _context;
    public Login(AppDbContext context)
    {
      _context = context;
    }
    public UserLogin CheckUserIn(UserLogin user)
    {
      var list = _context.Users.ToList();
      var existingUser = _context.register
                                 .Where(c => c.username == user.Username)
                                 .Select(c => new UserLogin
                                 {
                                   Username = c.username
                                  
                                   // Add other properties if needed
                                 })
                                 .FirstOrDefault();

      // Return the existing user if found, otherwise return a new UserLogin object
      return existingUser ?? null;
    }
    public UserLogin RecordLoginData(UserLogin user)
    {
      try
      {
        var result = _context.Users.Add(user);
        _context.SaveChanges();
        return user;
      }
      catch
      {
        return null;
      }
    }
  }
}
