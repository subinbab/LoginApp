using Core.AbstractModels.Project;
using Infrastructure.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.ProjectCRUD;

namespace UseCases.UseCases.ProjectOperation
{
  public class UseCasesProjectOperations : IUseCasesProjectOperations
  {
    private IProjectOperation _projectOperations { get; set; }
    public UseCasesProjectOperations(IProjectOperation projectOperations)
    {
      _projectOperations = projectOperations;
    }
    public ProjectModel CreateProject(ProjectModel project)
    {
      try
      {
        //ProjectCreate.CreateAPIProject();
        var result = _projectOperations.CreateProject(project);
        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}
