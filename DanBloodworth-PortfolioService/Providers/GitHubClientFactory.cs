using System;
using DanBloodworth_PortfolioService.Settings;
using Microsoft.Extensions.Options;
using Octokit;

namespace DanBloodworth_PortfolioService.Providers
{
    public class GitHubClientFactory : IGitHubClientFactory
    {
        private readonly IOptions<GitHubClientSettings> _options;

        public GitHubClientFactory(IOptions<GitHubClientSettings> options)
        {
            _options = options;
        }

        public IGitHubClient CreateClient(string apiKey)
        {
            return new GitHubClient(new ProductHeaderValue(_options.Value.ApplicationName),
                new Uri(_options.Value.ServerUrl))
            {
                Credentials = new Credentials(apiKey)
            };
        }
    }
}