using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactory200
{
    /// <summary>
    /// TYPED CLIENTS - SAMPLE
    /// </summary>
    public class MyGitHubClient
    {
        public HttpClient Client { get; }
        public MyGitHubClient(HttpClient client)
        {
            Client = client;
        }

    }
}
