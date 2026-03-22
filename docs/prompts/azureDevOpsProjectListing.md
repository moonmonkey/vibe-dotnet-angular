# Feature Prompt: Azure DevOps Project Listing (Backend)

Feature: Connect to Azure DevOps and list all projects in the organization.

## Tasks

1. Create a DTO in `Dtos/AzureDevOpsProjectDto.cs` with all relevant Azure DevOps project data:
   - Id (string) — the project ID
   - Name (string) — the project name
   - Description (string) — project description
   - Url (string) — the project URL
   - State (string) — project state (e.g., "wellFormed", "createPending", "deleted")
   - Visibility (string) — project visibility (e.g., "public", "private")

2. Add method to `IAzureDevOpsService` in `Services/IAzureDevOpsService.cs`:
   - Task<IEnumerable<AzureDevOpsProjectDto>> GetProjectsAsync()

3. Implement the method in `AzureDevOpsService` in `Services/AzureDevOpsService.cs`:
   - Uses injected HttpClient
   - Uses AzureDevOpsConfig for Organization and PersonalAccessToken
   - Calls Azure DevOps REST API to retrieve all projects
   - Deserialise the API response directly into `AzureDevOpsProjectDto` — do not create intermediate private model classes for this response
   - Use the shared generic wrapper `ApiResponse<T>` from `Models/ApiResponse.cs` to deserialise the paged response — e.g. `ApiResponse<AzureDevOpsProjectDto>`
   - `ApiResponse<T>` has a single property `List<T> Value` and is used across all Azure DevOps list responses

4. Add endpoint to `PrController` in `Controllers/PrController.cs`:
   - GET /api/pr/projects → returns IEnumerable<AzureDevOpsProjectDto>

## Notes
- This uses the same `PrController` as the PR listing feature
- Reuse existing `AzureDevOpsService` and `IAzureDevOpsService`
- No new service registration needed (already done in prior feature)
- `ApiResponse<T>` lives in `Models/ApiResponse.cs` and is the standard wrapper for all Azure DevOps paged list responses