# Feature Prompt: Azure DevOps Pull Request Listing (Backend)

You are assisting with a .NET 10 ASP.NET Core Web API project using Program.cs + Startup.cs (do NOT convert to minimal APIs).

Feature: Connect to Azure DevOps and list pull requests.

Tasks:
1. Create a DTO in # Feature Prompt: Azure DevOps Pull Request Listing (Backend)

You are assisting with a .NET 10 ASP.NET Core Web API project using Program.cs + Startup.cs (do NOT convert to minimal APIs).

Feature: Connect to Azure DevOps and list pull requests.

Tasks:

1. Create a DTO in `Dtos/PrDto.cs` with these properties:
   - Id (int)
   - Title (string)
   - Description (string)
   - Status (string)
   - CreatedBy (string) — the author of the PR

2. Create a service interface `IAzureDevOpsService` in `Services/IAzureDevOpsService.cs` with:
   - Task<IEnumerable<PrDto>> GetPullRequestsAsync(string project, string repositoryId)

3. Create a service implementation `AzureDevOpsService` in `Services/AzureDevOpsService.cs` that:
   - Uses injected HttpClient from `AddHttpClient` in Startup.cs
   - Uses a typed configuration object `AzureDevOpsConfig` for Organization and PersonalAccessToken
   - Maps PRs from Azure DevOps API to `PrDto`, including `createdBy.displayName`

4. Create a controller `PrController` in `Controllers/PrController.cs` with:
   - GET /api/pr/prs?project=<project>&repositoryId=<repo> → returns IEnumerable<PrDto>

5. Register the service in Startup.cs using `services.AddHttpClient<IAzureDevOpsService, AzureDevOpsService>()`.

6. Follow these rules (from system prompt):
   - Do NOT modify Program.cs
   - Place DTOs in Dtos/ folder
   - Services use constructor injection
   - Only generate new or changed files
   - Keep backend in backend/ folder

# Additional instructions:
- Create the relevant settings in appsettings
- Also I want to inject AzureDevOpsConfig so I can use it in constructors instead of IOptions

# Additional instructions:
- I think the base address in the AzureDevOpsService should be an appsetting, in AzureDevops, add it to the config class too