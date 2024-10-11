using Core.AbstractModels.Project;

namespace UseCases.UseCases.ProjectOperation
{
  public interface IUseCasesProjectOperations
  {
    ProjectModel CreateProject(ProjectModel project);
  }
}