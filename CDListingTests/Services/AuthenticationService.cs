using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CDListingTests.Services
{
    class AuthenticationService
    {
        private readonly ListingService ListingService;
        public const string IdentityServerUrl = "https://stage-id.awscalnp.manheim.com";
        public IConfiguration Configuration { get; set; }

        public AuthenticationService(ListingService listingService) => ListingService = listingService;

        public async Task<string> GetToken()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            Configuration = configurationBuilder.Build();
            var credentials = new Dictionary<string, string>
                {
                    {"Content-Type",Configuration["Content-Type"] },
                    {"client_id", Configuration["client_id"] },
                    {"client_secret",Configuration["client_secret"] },
                    {"grant_type",Configuration["grant_type"] },
                    {"UserName",Configuration["Username"] },
                    {"Password",Configuration["Password"] }
                };
            var request = new HttpRequestMessage(HttpMethod.Post, $"{IdentityServerUrl}/connect/token");
            request.Content = new FormUrlEncodedContent(credentials);

            var response = await ListingService.Execute(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"An error occured while getting token. {response.ReasonPhrase}");
            }
            var obj = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

            return obj.access_token;

        }

    }
}
