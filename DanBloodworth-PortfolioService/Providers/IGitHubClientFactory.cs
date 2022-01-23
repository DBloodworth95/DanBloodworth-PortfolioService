using Octokit;

namespace DanBloodworth_PortfolioService.Providers
{
    public interface IGitHubClientFactory
    {
        public IGitHubClient CreateClient(string apiKey);
    }
}