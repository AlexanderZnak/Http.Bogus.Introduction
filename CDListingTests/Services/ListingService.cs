using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDListingTests
{
    class ListingService
    {
        public const string ListingServerUrl = "https://stage-api.awscalnp.manheim.com/listing-service";
        private readonly ILogger Logger;
        private static readonly HttpClient Client = new HttpClient();

        public ListingService(ILogger<ListingService> logger) => Logger = logger;

        public async Task<HttpResponseMessage> CreateListing(string token, ListingHttp listing)
        {
            var request = CreateRestRequest(method: HttpMethod.Post, uri: $"{ListingServerUrl}/listings/", authorization: "Authorization", bearerToken: $"Bearer {token}", payload: listing);
            var response = await Execute(request);

            return response;
        }

        public async Task<HttpResponseMessage> GetListing(string id, string token)
        {
            var request = CreateRestRequest(method: HttpMethod.Get, uri: $"{ListingServerUrl}/listings/id/{id}", authorization: "Authorization", bearerToken: $"Bearer {token}");
            var response = await Execute(request);

            return response;
        }

        public async Task<HttpResponseMessage> UpdateListing(string id, string token, ListingHttp listing)
        {
            var request = CreateRestRequest(method: HttpMethod.Put, uri: $"{ListingServerUrl}/listings/id/{id}", authorization: "Authorization", bearerToken: $"Bearer {token}", payload: listing);
            var response = await Execute(request);

            return response;
        }


        public async Task<HttpResponseMessage> DeleteListing(string id, string token)
        {
            var request = CreateRestRequest(method: HttpMethod.Delete, uri: $"{ListingServerUrl}/listings/id/{id}", authorization: "Authorization", bearerToken: $"Bearer {token}");
            var response = await Execute(request);

            return response;
        }

        public HttpRequestMessage CreateRestRequest(HttpMethod method, string uri, string authorization, string bearerToken, object payload = null)
        {
            var request = new HttpRequestMessage(method, uri);
            request.Headers.Add(authorization, bearerToken);

            if (payload != null)
            {
                string jsonPayload = JsonConvert.SerializeObject(payload);
                Logger.LogInformation($"Payload is: {jsonPayload}");
                HttpContent httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                request.Content = httpContent;
            }

            return request;
        }

        public async Task<HttpResponseMessage> Execute(HttpRequestMessage request)
        {
            var response = await Client.SendAsync(request);
            Log(response);

            return response;
        }

        private async void Log(HttpResponseMessage response)
        {
            Logger.LogInformation($"{response.RequestMessage.Method} request to : {response.RequestMessage.RequestUri}");
            Logger.LogInformation($"Request finished with status code : {response.StatusCode}");
            string content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
                Logger.LogDebug($"Response Content: {FormatRequestBody(content)}");
            }
        }

        public static string ExtractIdFromHeaders(HttpResponseMessage response) => response.Headers.Location.ToString().Split("listings/id/")[1];

        private static string FormatRequestBody(string body) => JToken.Parse(body).ToString(Formatting.Indented);

    }
}
