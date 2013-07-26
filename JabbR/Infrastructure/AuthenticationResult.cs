namespace JabbR.Infrastructure
{
    public class AuthenticationResult
    {
        public string ProviderName { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}