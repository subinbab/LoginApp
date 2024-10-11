using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractModels.User
{
  public class ApplicationUser :Microsoft.AspNetCore.Identity.IdentityUser
  {
    [Key]
    public int AccountId { get; set; }
    public Guid AccountGuid { get; set; }
    public string Salt { get; set; }
    public bool Verified { get; set; }
    public string Checksum { get; set; }
    public string Password { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
  }
}
