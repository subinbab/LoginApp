using ProjectModels.DotnetCore;
using ProjectModels.Projects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Command;
using XMLGenerator.XMLRead;

namespace Template.ProjectCRUD
{
  public  class ProjectCreate
  {
    public static void CreateAPIProject(ProjectBaseModel FolderPath, DotnetCoreCommands commands)
    {
      try
      {
        // Create an instance of the Random class
        Random random = new Random();
        string folder = random.Next().ToString();
        string path = FolderPath.architetureDetails.RootPath + folder;
        ExecuteCommand.ExecuteCMD("cmd.exe", "/c cd "+ FolderPath.architetureDetails.RootPath, FolderPath.architetureDetails.RootPath);
        ExecuteCommand.ExecuteCMD("cmd.exe", $"/c mkdir {folder}" , FolderPath.architetureDetails.RootPath);
        // Define the command you want to run (e.g., "dotnet --version")
        string command = "cmd.exe";
        string arguments = commands.Create; // Command arguments
        ExecuteCommand.ExecuteCMD("cmd.exe", "/c cd " + path, FolderPath.architetureDetails.RootPath);
        if (FolderPath.architetureDetails.Name == "clean")
        {
           command = "dotnet";
           arguments = commands.Install; // Command arguments
          ExecuteCommand.ExecuteCMD(command, arguments, path);
          command = "dotnet";
          arguments = commands.Create +folder; // Command arguments
          ExecuteCommand.ExecuteCMD(command, arguments, path);
        }
        else
        {
           command = "dotnet";
           arguments = "new webapi"; // Command arguments
        }
        
        

        //ProjectDeploy.DeployProject(path+ "\\bin\\Release\\net8.0\\publish" , path);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
