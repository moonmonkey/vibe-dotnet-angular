using System.Collections.Generic;
using System.Threading.Tasks;
using Vibe.Api.Dtos;

namespace Vibe.Api.Interfaces
{
    public interface IAzureDevOpsService
    {
        Task<IEnumerable<PrDto>> GetPullRequestsAsync(string project, string repositoryId);
        Task<IEnumerable<PrDto>> GetPullRequestsByUserAsync(string user);
    }
}
