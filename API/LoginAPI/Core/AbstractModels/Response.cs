using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractModels
{
  public abstract class ResponseBaseModel<T>
  {
    public bool status { get; set; }
    public T response { get; set; }
    public string message { get; set; }
  }
}
