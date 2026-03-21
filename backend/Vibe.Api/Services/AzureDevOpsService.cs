using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Vibe.Api.Dtos;
using Vibe.Api.Interfaces;

namespace Vibe.Api.Services
{
    public class AzureDevOpsService : IAzureDevOpsService
    {
        private readonly HttpClient _httpClient;

        public AzureDevOpsService(HttpClient httpClient, AzureDevOpsConfig config)
        {
            _httpClient = httpClient;

            // configuration is assumed to exist and be valid; BaseAddress must be provided
            _httpClient.BaseAddress = new Uri(config.BaseAddress);

            var token = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{config.PersonalAccessToken}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<PrDto>> GetPullRequestsAsync(string project, string repositoryId)
        {
            if (string.IsNullOrWhiteSpace(project) || string.IsNullOrWhiteSpace(repositoryId))
            {
                return Array.Empty<PrDto>();
            }

            // Azure DevOps REST API for pull requests
            var url = $"{project}/_apis/git/repositories/{repositoryId}/pullrequests?api-version=7.0";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<PullRequestResponse>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result?.Value?.Select(pr => new PrDto
            {
                Id = pr.PullRequestId,
                Title = pr.Title,
                Description = pr.Description,
                Status = pr.Status,
                CreatedBy = pr.CreatedBy?.DisplayName ?? string.Empty
            }) ?? Array.Empty<PrDto>();
        }

        public async Task<IEnumerable<PrDto>> GetPullRequestsByUserAsync(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                return Array.Empty<PrDto>();
            }

            // Azure DevOps REST API to search PRs across organization
            // Uses search criteria: createdBy={user}
            var encodedUser = Uri.EscapeDataString(user);
            var url = $"_apis/git/pullrequests?searchCriteria.createdBy={encodedUser}&api-version=7.0";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<PullRequestResponse>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result?.Value?.Select(pr => new PrDto
            {
                Id = pr.PullRequestId,
                Title = pr.Title,
                Description = pr.Description,
                Status = pr.Status,
                CreatedBy = pr.CreatedBy?.DisplayName ?? string.Empty
            }) ?? Array.Empty<PrDto>();
        }

        private class PullRequestResponse
        {
            public List<PullRequest> Value { get; set; }
        }

        private class PullRequest
        {
            public int PullRequestId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public CreatedBy CreatedBy { get; set; }
        }

        private class CreatedBy
        {
            public string DisplayName { get; set; }
        }
    }
}