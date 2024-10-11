using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Command;

namespace ProjectScanner.ProjectReader
{
  public class AddReference
  {
    public static void AddReferences()
    {
      try
      {

      }
      catch (Exception ex)
      {

      }
    }
    public static string FindCSProj()
    {
      try
      {
        string rootDirectory = @"D:\CodeGenProj\760054651";

        // Find all .csproj files in the folder and subfolders
        string[] csprojFiles = Directory.GetFiles(rootDirectory, "*.csproj", SearchOption.AllDirectories);
        string currentDirectory = Directory.GetCurrentDirectory();

        foreach (string file in csprojFiles)
        {
          Console.WriteLine(file);
          ExecuteCommand.ExecuteCMD("dotnet", "add C:\\Projects\\Angular\\Login-App\\Login\\API\\LoginAPI\\TestToDo\\TestToDo.csproj reference " + file, currentDirectory);
        }

        return "";
      }
      catch (Exception ex)
      {
        return "";
      }
    }
  }
}
