using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactory200.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamedClientController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NamedClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient("GitHubClient");
            var result = await client.GetStringAsync("/");

            return Ok(result);
        }
    }
}