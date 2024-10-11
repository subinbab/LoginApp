using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProjectModels.Projects
{
  [XmlRoot("Project")]
  public class ProjectBaseModel
  {
    public string ProjectType { get; set; } = string.Empty;
    public string ProjectName { get; set; }
    public string ProjectVersion { get; set; }
    public string ProjectDescription { get; set; }
    public string ProjectVersionDescription { get; set; }
    public ArchitetureDetails architetureDetails { get; set; }
    public string apiProgramecsFilePath { get; set; } 
  }
  public class ArchitetureDetails
  {
    [XmlElement("Name")]
    public string Name { get; set; }
    [XmlElement("RootPath")]
    public string RootPath { get; set; }
  }
}
