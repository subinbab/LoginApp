using ProjectModels.DotnetCore;
using ProjectModels.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLGenerator.XMLRead
{
    public class ReadDotnetCommands
    {
    public static DotnetCoreCommands ReadCommands(string path)
    {
      DotnetCoreCommands bookStore = null;
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(DotnetCoreCommands));
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
          // Deserialize XML to BookStore object
          bookStore = (DotnetCoreCommands)serializer.Deserialize(fs);

          // Access properties of the deserialized object
          Console.WriteLine("Name: " + bookStore.Create);
        }
        return bookStore;
      }
      catch (Exception ex)
      {
        return bookStore;
      }
    }
  }
}
