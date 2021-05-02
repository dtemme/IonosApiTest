using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ionos.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DataController : ControllerBase
    {
        private readonly HttpMessageHandler httpMessageHandler;

        public DataController()
        {
            httpMessageHandler = new HttpClientHandler
            {
                AllowAutoRedirect = true,
#if !DEBUG
                Proxy = new System.Net.WebProxy("http://winproxy.schlund.de:3128"),
#endif
            };
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
            using var httpClient = new HttpClient(httpMessageHandler);
            var response = await httpClient.GetStringAsync(testUrl).ConfigureAwait(false);
            return Ok(JsonConvert.DeserializeObject<dynamic>(response).stations[0]);
        }
    }
}