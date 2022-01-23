using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

namespace DanBloodworth_PortfolioService.Services
{
    public interface IProjectService
    {
        Task<IReadOnlyList<Repository>> GetGitHubRepositories(string apiKey);
    }
}