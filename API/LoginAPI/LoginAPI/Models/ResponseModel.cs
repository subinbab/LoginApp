using Newtonsoft.Json;

namespace LoginAPI.Models
{
  public class ResponseModel<T>
  {
    public ResponseModel()
    {
      IsSuccess = true;
      Message = "";
    }

    [JsonProperty("isSuccess")]
    public bool IsSuccess { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("data")]
    public T Data { get; set; }

    public string username { get; set; }
  }
}
