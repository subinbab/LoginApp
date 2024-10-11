using Core.AbstractModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractModels.Project
{
  public class ProjectModel
  {
    public Guid Id { get; set; }
    public Guid registerId { get; set; }
    public Core.AbstractModels.Register.Register register{ get; set; }
    public string projectType { get; set; }
    public string projectName { get; set; } = string.Empty;
    public string projectDescription { get; set; }
    public string projectVersion { get; set; }
    public string projectSubscription {  get; set; }

  }
}
