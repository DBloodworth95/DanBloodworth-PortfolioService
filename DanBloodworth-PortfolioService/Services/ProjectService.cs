using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IReadOnlyList<Repository>> GetGitHubRepositories(string apiKey)
        {
            var client = _gitHubClientFactory.CreateClient(apiKey);
            var repositories = await client.Repository.GetAllPublic();

            return repositories;
        }
    }
}