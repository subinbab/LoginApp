using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Template.Command
{
  public interface IISCommands
  {
    public static void IISCreateWeb(string path , string websitename , string workingDir)
    {
      try
      {
        // appcmd add site / name:"YourWebsiteName" / bindings:"http/*:80:YourWebsiteName" / physicalPath:"C:\path\to\your\build\folder"
        string command = "appcmd";
        string arguments = $"add site /name:{websitename} /bindings:\"http/*:80:YourWebsiteName\" /physicalPath:{path}"; // Command arguments
        ExecuteCommand.ExecuteCMD(command, arguments , workingDir);

      }
      catch (Exception ex)
      {

      }
    }
  }
}
