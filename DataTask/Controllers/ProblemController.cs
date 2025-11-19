using Microsoft.AspNetCore.Mvc;
using DataTask.Services;

namespace DataTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProblemController : ControllerBase
    {
        private readonly ProblemService _service;

        public ProblemController(ProblemService service)
        {
            _service = service;
        }

        // GET: api/problem/debug
        [HttpGet("debug")]
        public async Task<IActionResult> Debug()
        {
            try
            {
                var response = await _service.DebugApiResponseAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new { error = ex.Message });
            }
        }

        // GET: api/problem/raw
        [HttpGet("raw")]
        public async Task<IActionResult> Raw() =>
            Ok(await _service.GetRawAsync());

        // GET: api/problem/top-plants
        [HttpGet("top-plants")]
        public async Task<IActionResult> TopPlants() =>
            Ok(await _service.GetTopPlantsAsync());
    }
}