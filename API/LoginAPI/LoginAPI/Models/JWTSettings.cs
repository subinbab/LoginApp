namespace LoginAPI.Models
{
  public class JWTSettings
  {
    public string Secret { get; set; }

    public TimeSpan TokenLifetime { get; set; }
  }
  public class ServiceConfiguration
  {
    public JWTSettings JwtSettings { get; set; }
  }
}
