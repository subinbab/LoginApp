namespace LoginAPI.Models
{
  public class AuthenticationResult:TokenModel
  {
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; }
  }
}
