using System.Collections.Generic;

namespace Vibe.Api.Models
{
    public class ApiResponse<T>
    {
        public List<T> Value { get; set; }
    }
}
