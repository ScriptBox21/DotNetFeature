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
    public class EncapsulatingClientController : ControllerBase
    {
        private readonly IMyGitHubClient _gitHubClient;

        public EncapsulatingClientController(IMyGitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _gitHubClient.GetRootDataLength();
            return Ok(result);
        }
    }
}