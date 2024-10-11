using Core.AbstractModels.Project;

namespace Infrastructure.Project
{
  public interface IProjectOperation
  {
    ProjectModel CreateProject(ProjectModel project);
    List<ProjectModel> GetProjectList();
  }
}