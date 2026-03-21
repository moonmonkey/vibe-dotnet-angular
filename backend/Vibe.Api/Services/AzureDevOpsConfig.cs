namespace Vibe.Api.Services
{
    public class AzureDevOpsConfig
    {
        /// <summary>
        /// Full base URI for Azure DevOps REST API.  Example: https://dev.azure.com/my-org/
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// Organization name; may be used when BaseAddress is not specified.
        /// </summary>
        public string Organization { get; set; }

        public string PersonalAccessToken { get; set; }
    }
}