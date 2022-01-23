using System.Collections.Generic;
using System.Threading.Tasks;
using DanBloodworth_PortfolioService.Providers;
using DanBloodworth_PortfolioService.Settings;
using Microsoft.Extensions.Options;
using Octokit;

namespace DanBloodworth_PortfolioService.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGitHubClientFactory _gitHubClientFactory;
        private readonly IOptions<ProjectServiceSettings> _options;

        public ProjectService(IGitHubClientFactory gitHubClientFactory, 
            IOptions<ProjectServiceSettings> options)
        {
            _gitHubClientFactory = gitHubClientFactory;
            _options = options;
        }

        public async Task<IReadOnlyList<Repository>> GetGitHubRepositories(string apiKey)
        {
            var client = _gitHubClientFactory.CreateClient(_options.Value.ApiKey);
            var repositories = await client.Repository.GetAllForCurrent();

            return repositories;
        }
    }
}