using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Command
{
  public  class ExecuteCommand
  {
    public static void ExecuteCMD(string command , string arguments , string path )
    {
      try
      {
        // Create a new process to run the command
        var process = new Process
        {
          StartInfo = new ProcessStartInfo
          {
            FileName = command,  // Command to run
            Arguments = arguments, // Arguments for the command
            RedirectStandardOutput = true, // Redirect output
            UseShellExecute = false,  // Do not use shell, run directly
            CreateNoWindow = true, // Hide the command window
            WorkingDirectory = path // Change the working directory
          }
        };

        // Start the process and capture the output
        process.Start();

        // Read the output
        string result = process.StandardOutput.ReadToEnd();

        // Wait for the process to finish
        process.WaitForExit();

        // Display the output
        Console.WriteLine(result);
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
  }
}
