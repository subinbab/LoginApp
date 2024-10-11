using ProjectModels.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLGenerator.XMLRead
{
  public class XMLRead
  {
    public static ProjectBaseModel ReadfilePath(string path)
    {
      ProjectBaseModel bookStore = null;
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(ProjectBaseModel));
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
          // Deserialize XML to BookStore object
           bookStore = (ProjectBaseModel)serializer.Deserialize(fs);

          // Access properties of the deserialized object
          Console.WriteLine("Name: " + bookStore.architetureDetails.Name);
          Console.WriteLine("RootPath: " + bookStore.architetureDetails.RootPath);
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
