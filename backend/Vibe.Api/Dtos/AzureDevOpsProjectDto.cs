namespace Vibe.Api.Dtos
{
    public class AzureDevOpsProjectDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string State { get; set; }
        public string Visibility { get; set; }
    }
}