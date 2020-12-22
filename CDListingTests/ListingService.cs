using CAL.CD.Listings.API.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDListingTests
{
    class ListingService
    {
        public const string IdentityServerUrl = "https://stage-id.awscalnp.manheim.com";
        public const string ListingServerUrl = "https://stage-api.awscalnp.manheim.com/listing-service";
        private readonly ILogger Logger;

        public ListingService(ILogger<ListingService> logger) => Logger = logger;

        public async Task<string> GetToken()
        {
            var credentials = new Dictionary<string, string>
                {
                    {"Content-Type","application/x-www-form-urlencoded" },
                    {"client_id", "4e5d44e66a524ed3803d8720d6d77803" },
                    {"client_secret","eef75d60b49e46e68bd03a79297a90c2" },
                    {"grant_type","password" },
                    {"UserName","srctest2" },
                    {"Password","TeSt!2#4" }
                };
            var request = CreateRestRequest(method: HttpMethod.Post, uri: $"{IdentityServerUrl}/connect/token", credentials: credentials);
            var response = await Execute(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"An error occured while getting token. {response.ReasonPhrase}");
            }
            var obj = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

            return obj.access_token;

        }

        public async Task<HttpResponseMessage> CreateListing(string token)
        {
            var payload = ParseJson("createListing.json");
            var request = CreateRestRequest(method: HttpMethod.Post, uri: $"{ListingServerUrl}/listings/", authorization: "Authorization", bearerToken: $"Bearer {token}", payload: payload);
            var response = await Execute(request);

            return response;
        }

        public async Task<HttpResponseMessage> GetListing(string id, string token)
        {
            var request = CreateRestRequest(method: HttpMethod.Get, uri: $"{ListingServerUrl}/listings/id/{id}", authorization: "Authorization", bearerToken: $"Bearer {token}");
            var response = await Execute(request);

            return response;
        }

        public async Task<HttpResponseMessage> UpdateListing(string id, string token)
        {
            var payload = ParseJson("updateListing.json");
            var request = CreateRestRequest(method: HttpMethod.Put, uri: $"{ListingServerUrl}/listings/id/{id}", authorization: "Authorization", bearerToken: $"Bearer {token}", payload: payload);
            var response = await Execute(request);

            return response;
        }


        public async Task<HttpResponseMessage> DeleteListing(string id, string token)
        {
            var request = CreateRestRequest(method: HttpMethod.Delete, uri: $"{ListingServerUrl}/listings/id/{id}", authorization: "Authorization", bearerToken: $"Bearer {token}");
            var response = await Execute(request);

            return response;
        }

        public HttpRequestMessage CreateRestRequest(HttpMethod method, string uri, string authorization = null, string bearerToken = null, object payload = null, Dictionary<string, string> credentials = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if (authorization != null & bearerToken != null)
            {
                request.Headers.Add(authorization, bearerToken);
            }
            if (credentials != null)
            {
                request.Content = new FormUrlEncodedContent(credentials);
            }

            if (payload != null)
            {
                string jsonPayload = JsonConvert.SerializeObject(payload);
                HttpContent httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                request.Content = httpContent;
            }

            return request;

        }

        public async Task<HttpResponseMessage> Execute(HttpRequestMessage request)
        {
            using (var httpClient = new HttpClient(new HttpClientHandler(), true))
            {
                var response = await httpClient.SendAsync(request);
                Log(response);

                return response;
            }
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

        private static Listing ParseJson(string file)
        {
            try
            {
                return JsonConvert.DeserializeObject<Listing>(File.ReadAllText(file));
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"File: {file} doesn't exist");
            }
            catch (JsonReaderException)
            {
                throw new Exception($"Json deserialize didn't work due to {file} has json syntax errors");
            }

            //return default;
        }

        private static string FormatRequestBody(string body) => JToken.Parse(body).ToString(Formatting.Indented);

    }
}
