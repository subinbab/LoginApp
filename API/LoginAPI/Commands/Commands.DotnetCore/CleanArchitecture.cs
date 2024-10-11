using ProjectModels.DotnetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLGenerator.XMLRead;

namespace Commands.Commands.DotnetCore
{
  public class CleanArchitecture
  {
    public DotnetCoreCommands FetchCommands()
    {
      var createCommands = ReadDotnetCommands.ReadCommands("C:\\Projects\\Angular\\Login-App\\Login\\API\\LoginAPI\\Commands\\CommandsXML\\clean_arch.xml");
      return new DotnetCoreCommands { Create = createCommands.Create , Install = createCommands.Install};
    }
  }
}
