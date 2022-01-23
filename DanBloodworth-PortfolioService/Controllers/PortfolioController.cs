using System.Threading.Tasks;
using DanBloodworth_PortfolioService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanBloodworth_PortfolioService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<PortfolioController> _logger;

        public PortfolioController(ILogger<PortfolioController> logger, 
            IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpGet("projects")]
        public async Task<IActionResult> Get()
        {
            var repositories = await _projectService.GetGitHubRepositories("todo");
            
            return Ok(repositories);
        }
    }
}