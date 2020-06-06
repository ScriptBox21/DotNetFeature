using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactory200.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypedClientController : ControllerBase
    {
        private readonly MyGitHubClient _gitHubClient;

        public TypedClientController(MyGitHubClient gitGitHubClient)
        {
            _gitHubClient = gitGitHubClient;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _gitHubClient.Client.GetStringAsync("/");
            return Ok(result);
        }
    }
}