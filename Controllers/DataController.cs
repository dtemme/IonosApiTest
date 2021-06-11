using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Ionos.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ionos.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DataController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

        public DataController(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Value = "Hello from GET" });
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok(new { Value = "Hello from POST" });
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok(new { Value = "Hello from PUT" });
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            return Ok(new { Value = "Hello from PATCH" });
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok(new { Value = "Hello from DELETE" });
        }

        [HttpGet("proxy")]
        public async Task<IActionResult> GetFromExternalUrl()
        {
            var testUrl = "https://creativecommons.tankerkoenig.de/json/list.php?lat=52.521&lng=13.438&rad=1.5&sort=dist&type=all&apikey=00000000-0000-0000-0000-000000000002";
            var response = await httpClient.GetStringAsync(testUrl).ConfigureAwait(false);
            return Ok(JsonSerializer.Deserialize<TankerKoenigListResult>(response, jsonSerializerOptions).Stations.FirstOrDefault());
        }
    }
}