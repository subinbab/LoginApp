using ProjectModels.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLGenerator.XMLUpdate
{
  public class XMLDotnetUpdate
  {
    public static void Update(ProjectBaseModel project , string path)
    {
      try
      {
        // Load the existing XML file and deserialize it into the C# object
        XmlSerializer serializer = new XmlSerializer(typeof(ProjectBaseModel));

        //using (FileStream fileStream = new FileStream("project.xml", FileMode.Open))
        //{
        //  project = (ProjectBaseModel)serializer.Deserialize(fileStream);
        //}

        // Now the 'project' object contains the deserialized data from the XML file
        // Let's update some properties
        //project.ProjectName = "UpdatedProjectName";
        //project.architetureDetails.RootPath = "/new/path/to/project";

        // Serialize the updated object back to XML and save it to the file
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
          serializer.Serialize(fileStream, project);
        }

        Console.WriteLine("XML file updated from the C# object.");
      }
      catch (Exception ex)
      {

      }
    }
  }
}
