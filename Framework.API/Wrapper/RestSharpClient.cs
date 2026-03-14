using System;
using System.Threading.Tasks;
using Framework.Core.Interfaces;
using RestSharp;

namespace Framework.API.Wrapper
{
    public class RestSharpClient : IApiClient
    {
        private readonly RestClient _client;

        // Pass the Base URL when initializing the client
        public RestSharpClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<string> GetAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = await _client.ExecuteAsync(request);

            EnsureSuccess(response);
            return response.Content??string.Empty;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = await _client.ExecuteAsync<T>(request);

            EnsureSuccess(response);
            return response.Data;
        }

        public async Task<T> PostAsync<T>(string endpoint, object payload)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(payload); // Automatically serializes C# object to JSON

            var response = await _client.ExecuteAsync<T>(request);

            EnsureSuccess(response);
            return response.Data;
        }

        // Helper method to throw clear errors if the API fails
        private void EnsureSuccess(RestResponse response)
        {
            if (!response.IsSuccessful)
            {
                throw new Exception($"API Request failed! Status: {response.StatusCode}, Content: {response.Content}");
            }
        }
    }
}