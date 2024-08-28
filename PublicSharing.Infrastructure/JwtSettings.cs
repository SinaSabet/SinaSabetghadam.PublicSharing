namespace PublicSharing.Infrastructure
{
    public class JwtSettings
    {
        public const string Section = "JwtSettings";

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}