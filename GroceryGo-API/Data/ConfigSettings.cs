namespace GroceryGo_API.Data
{
    public class ConfigSettings
    {
        public string TokenSecretKey { get; set; }
        public int TokenExpiration { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
