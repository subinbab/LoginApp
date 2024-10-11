using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLGenerator.XMLCreate
{
  public class XMLCreateFile
  {
    public XMLCreateFile()
    {
          
    }
    public static void CreateFile(string path)
    {
      try
      {
        using (XmlWriter writer = XmlWriter.Create(path+"\\example.xml"))
        {
          writer.WriteStartDocument();
          writer.WriteStartElement("Project");

          writer.WriteStartElement("Architecture");
          writer.WriteElementString("Name", "Clean");
          writer.WriteElementString("RootPath", "D:\\CodeGenProj");
          writer.WriteEndElement(); // End Book

          writer.WriteEndElement(); // End BookStore
          writer.WriteEndDocument();
        }

        Console.WriteLine("XML file created successfully!");
      }
      catch (Exception ex)
      {
        
      }
    }
  }
}
