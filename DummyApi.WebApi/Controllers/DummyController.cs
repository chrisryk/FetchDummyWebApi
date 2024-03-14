using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummyApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetData([FromQuery] DummyParameters parameters)
        {
            var baseUrl = "https://dummyapi.io/";
            var path = "data/v1/user";
            var filter = $"?page={parameters.Page}&limit={parameters.Limit}";
            var idHeader = "65eec7d4f88b2863bdc09cc1";

            var client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("app-id", idHeader);
            var response = await client.GetAsync(path + filter);

            var result = await response.Content.ReadAsStringAsync();

            return Ok(result);
        }
    }
}
