public class RefreshToken
{
  public Guid RefreshTokenId { get; set; }
  public string Token { get; set; }
  public string jwtId { get; set; }
  public string userId { get; set; }
  public DateTime creatiomDate { get; set; }
  public DateTime ExpiryDate { get; set; }

}
