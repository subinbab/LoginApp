using Core.AbstractModels.Project;
using Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Project
{
  public class ProjectOperation : IProjectOperation
  {
    private AppDbContext _appDbContext { get; set; }
    public ProjectOperation(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public ProjectModel CreateProject(ProjectModel project)
    {
      try
      {
        _appDbContext.Add(project);
        _appDbContext.SaveChanges();
        return project;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
    public List<ProjectModel> GetProjectList()
    {
      try
      {
        return _appDbContext.projectModels.ToList();
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}
