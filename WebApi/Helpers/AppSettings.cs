namespace WebApi.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public long ExpirationTimeMinutes { get; set; }
    }
}