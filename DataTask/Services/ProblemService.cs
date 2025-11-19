using DataTask.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace DataTask.Services
{
    public class ProblemService
    {
        private readonly HttpClient _http;
        private const string JsonUrl = "https://get.data.gov.lt/datasets/gov/lzukt/Ivertis";

        public ProblemService(HttpClient http)
        {
            _http = http;
        }

        // Debug method to see raw API response
        public async Task<object> DebugApiResponseAsync()
        {
            try
            {
                var response = await _http.GetStringAsync(JsonUrl);
                return new { RawResponse = response };
            }
            catch (Exception ex)
            {
                return new { Error = ex.Message };
            }
        }

        // Load all data from the API
        public async Task<List<ProblemRecord>> LoadDataAsync()
        {
            try
            {
                // Try to get the response as a string first
                var jsonString = await _http.GetStringAsync(JsonUrl);

                // Try parsing as PlantDataResponse (with _data wrapper)
                try
                {
                    var wrappedResponse = JsonSerializer.Deserialize<PlantDataResponse>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (wrappedResponse?.Data != null && wrappedResponse.Data.Any())
                    {
                        Console.WriteLine($"Loaded {wrappedResponse.Data.Count} records with _data wrapper");
                        return wrappedResponse.Data;
                    }
                }
                catch
                {
                    // If that fails, try parsing as direct array
                    var directResponse = JsonSerializer.Deserialize<List<ProblemRecord>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (directResponse != null && directResponse.Any())
                    {
                        Console.WriteLine($"Loaded {directResponse.Count} records as direct array");
                        return directResponse;
                    }
                }

                Console.WriteLine("No data found in response");
                return new List<ProblemRecord>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                return new List<ProblemRecord>();
            }
        }

        // Return first 10 records
        public async Task<IEnumerable<ProblemRecord>> GetRawAsync()
        {
            var data = await LoadDataAsync();
            Console.WriteLine($"GetRawAsync: Returning {data.Count} total records");
            return data.Take(10);
        }

        // Top 5 plants with most reports
        public async Task<IEnumerable<object>> GetTopPlantsAsync()
        {
            var data = await LoadDataAsync();
            Console.WriteLine($"GetTopPlantsAsync: Processing {data.Count} records");

            var result = data
                .Where(p => !string.IsNullOrEmpty(p.PlantName))
                .GroupBy(p => p.PlantName)
                .Select(g => new { Plant = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();

            Console.WriteLine($"GetTopPlantsAsync: Found {result.Count} plant groups");
            return result;
        }
    }
}