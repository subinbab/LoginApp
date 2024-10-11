using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectModels.DotnetCore
{
  [XmlRoot("Commands")]
  public class DotnetCoreCommands
  {
    [XmlElement("Create")]
    public string Create { get; set; }
    [XmlElement("Install")]
    public string Install { get; set; }

  }
  
}
