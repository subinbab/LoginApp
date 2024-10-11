using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectScanner.Models
{
  public class ClassProps
  {
    public string Name { get; set; }
    public List<string> InheritedElem { get; set; }
    public List<string> MethodList { get; set; }
    public ClassProps()
    {
        Name = string.Empty;
        InheritedElem = new List<string>();
        MethodList = new List<string>();
    }
  }
}
