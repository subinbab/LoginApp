using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Command;

namespace Template.ProjectCRUD
{
  public  class ProjectDeploy
  {
    public static void DeployProject(string path ,string workingDir)
    {
      string command = "";
      string arguments = "";
      try
      {
       
        //dotnet build
        command = "dotnet";
         arguments = "build"; // Command arguments
        ExecuteCommand.ExecuteCMD(command, arguments , workingDir);

        //dotnet publish
         command = "dotnet";
         arguments = "publish"; // Command arguments
        ExecuteCommand.ExecuteCMD(command, arguments , workingDir);

        //IIS deploy
        IISCommands.IISCreateWeb(path , "web1" , workingDir);


      }
      catch (Exception ex)
      {

      }
    }
  }
}
