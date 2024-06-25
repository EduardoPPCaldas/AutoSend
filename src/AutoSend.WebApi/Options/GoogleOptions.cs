namespace AutoSend.WebApi.Options;

public class GoogleOptions
{
    public const string Configuration = "Authentication:Google";
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}
