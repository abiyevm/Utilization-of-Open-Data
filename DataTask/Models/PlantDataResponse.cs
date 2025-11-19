using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataTask.Models
{
    public class PlantDataResponse
    {
        [JsonPropertyName("_data")]
        public List<ProblemRecord> Data { get; set; } = new List<ProblemRecord>();

        [JsonPropertyName("_page")]
        public object Page { get; set; } // Optional for pagination
    }
}
