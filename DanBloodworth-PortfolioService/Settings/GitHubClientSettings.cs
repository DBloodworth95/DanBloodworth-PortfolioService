namespace DanBloodworth_PortfolioService.Settings
{
    public class GitHubClientSettings
    {
        public string ServerUrl { get; set; }
        public string ApplicationName { get; set; }

        public GitHubClientSettings(string serverUrl, string applicationName)
        {
            ServerUrl = serverUrl;
            ApplicationName = applicationName;
        }
    }
}