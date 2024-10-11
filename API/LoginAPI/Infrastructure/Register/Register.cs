using Infrastructure.DB;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Register
{
  public class Register : IRegisterUser
  {
    private AppDbContext _context;
    public Register(AppDbContext context)
    {
      _context = context;
    }
    public EntityEntry<Core.AbstractModels.Register.Register> RegisterUser(Core.AbstractModels.Register.Register register)
    {
      {
        try
        {
          var result = _context.Add(register);
          _context.SaveChanges();
          return result;
        }
        catch (Exception ex)
        {
          return null;
        }
      }
    }
  }
}
