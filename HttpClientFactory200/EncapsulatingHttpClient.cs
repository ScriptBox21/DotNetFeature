using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactory200
{
    public interface IMyGitHubClient
    {
        Task<int> GetRootDataLength();
    }

    public class EncapsulatingHttpClient : IMyGitHubClient
    {
        private readonly HttpClient _client;

        public EncapsulatingHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<int> GetRootDataLength()
        {
            var data = await _client.GetStringAsync("/");
            return data.Length;
        }
    }
}
