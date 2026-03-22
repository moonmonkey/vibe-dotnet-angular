using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vibe.Api.Dtos;
using Vibe.Api.Interfaces;

namespace Vibe.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrController : ControllerBase
    {
        private readonly IAzureDevOpsService _azureDevOpsService;

        public PrController(IAzureDevOpsService azureDevOpsService)
        {
            _azureDevOpsService = azureDevOpsService;
        }

        [HttpGet("prs")]
        public async Task<IEnumerable<PrDto>> GetPullRequests([FromQuery] string project, [FromQuery] string repositoryId)
        {
            return await _azureDevOpsService.GetPullRequestsAsync(project, repositoryId);
        }

        [HttpGet("user/{user}")]
        public async Task<IEnumerable<PrDto>> GetPullRequestsByUser([FromRoute] string user)
        {
            return await _azureDevOpsService.GetPullRequestsByUserAsync(user);
        }

        [HttpGet("projects")]
        public async Task<IEnumerable<AzureDevOpsProjectDto>> GetProjects()
        {
            return await _azureDevOpsService.GetProjectsAsync();
        }
    }
}