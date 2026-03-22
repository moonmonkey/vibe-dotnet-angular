# Azure DevOps Project Listing Feature Prompt

## Tasks Overview

### 1. DTO (Data Transfer Object)
- Create a DTO for representing the project listing data.
- Include properties such as ProjectId, ProjectName, ProjectDescription, RepositoryUrl, etc.

### 2. Service Interface
- Define an interface for the project listing service.
- Methods to include:
  - `IList<ProjectDto> GetProjects();`
  - `ProjectDto GetProjectById(int projectId);`

### 3. Service Implementation
- Implement the service interface.
- Use dependency injection for instantiating the data access layer.
- Ensure proper error handling and logging.

### 4. Controller Endpoint
- Create a controller that handles HTTP requests for project listings.
- Implement the following endpoints:
  - `GET /api/projects` - Retrieves a list of projects.
  - `GET /api/projects/{id}` - Retrieves a project by ID.

### 5. Notes
- Ensure to validate the input and return appropriate HTTP status codes.
- Consider pagination for the project listing if the number of projects is large.
- Use Swagger for API documentation.
- Implement unit tests for the service and controller logic.