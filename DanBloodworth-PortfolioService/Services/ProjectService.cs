using Octokit;

namespace DanBloodworth_PortfolioService.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGitHubClient _gitHubClient;

        public ProjectService(IGitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient;
        }
    }
}