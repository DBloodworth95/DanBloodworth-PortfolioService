using DanBloodworth_PortfolioService.Providers;
using Octokit;

namespace DanBloodworth_PortfolioService.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGitHubClientFactory _gitHubClientFactory;

        public ProjectService(IGitHubClientFactory gitHubClientFactory)
        {
            _gitHubClientFactory = gitHubClientFactory;
        }
    }
}