using Core.AbstractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Response
{
  public class ResponseData<T> : ResponseBaseModel<T> where T : class
  {
    public string resposeStatus { get; set; }
    public string resposeStatusMessage { get; set; }
    public string error {  get; set; }
  }
}
