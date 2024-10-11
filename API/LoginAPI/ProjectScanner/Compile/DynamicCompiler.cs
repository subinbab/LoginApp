using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectScanner.Compile
{
  public static class DynamicCompiler
  {
    public static object CompileAndInstantiate(string filePath, string className)
    {
      try
      {
        filePath = "D:\\CodeGenProj\\760054651\\760054651\\src\\Web\\Program.cs";
        className = "Program";
        // Read the C# code from the file
        string code = File.ReadAllText(filePath);

        // Parse the code into a syntax tree
        var syntaxTree = CSharpSyntaxTree.ParseText(code);

        // Create a compilation unit, adding any required references
        var compilation = CSharpCompilation.Create(
            "DynamicAssembly",
            new[] { syntaxTree },
            new[] {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),   // Reference to core types
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location)  // Reference to System.Console
            },
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        // Compile the code into an in-memory assembly
        using (var ms = new MemoryStream())
        {
          var result = compilation.Emit(ms);

          if (!result.Success)
          {
            // Handle compilation errors
            foreach (var diagnostic in result.Diagnostics)
            {
              Console.WriteLine(diagnostic.ToString());
            }

            throw new Exception("Compilation failed!");
          }

          // Load the compiled assembly from memory
          ms.Seek(0, SeekOrigin.Begin);
          var assembly = Assembly.Load(ms.ToArray());

          // Get the type (class) by its name
          var type = assembly.GetType(className);

          if (type == null)
          {
            throw new Exception($"Class {className} not found in the compiled assembly.");
          }

          // Create an instance of the class
          return Activator.CreateInstance(type);
        }

      }
      catch (Exception ex) {
        return null;
      }
    }
  }

}
