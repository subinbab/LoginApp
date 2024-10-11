using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractModels.Register
{
  public abstract class RegisterBaseClass
  {
    public Guid id { get; set; }
    public string first_name { get; set; }
    public string second_name { get; set; }
    public string dob {  get; set; }
    public string username { get; set; }
    public string password { get; set; }
  }
}
