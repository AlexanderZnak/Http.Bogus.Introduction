using CDListingTests.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CDListingTests.Services
{
    internal class AuthenticationService
    {
        private readonly ListingService ListingService;
        public const string IdentityServerUrl = "https://stage-id.awscalnp.manheim.com";
        private readonly IdentitySettings _identitySettings = ConfigManager.GetInstance().IdentitySettings;

        public AuthenticationService(ListingService listingService) => ListingService = listingService;

        public async Task<string> GetToken()
        {
            var credentials = new Dictionary<string, string>
                {
                    {"Content-Type", _identitySettings.ContentType},
                    {"client_id", _identitySettings.ClientId },
                    {"client_secret", _identitySettings.ClientSecret },
                    {"grant_type", _identitySettings.GrantType },
                    {"UserName", _identitySettings.UserName },
                    {"Password", _identitySettings.Password }
                };
            var request = new HttpRequestMessage(HttpMethod.Post, $"{IdentityServerUrl}/connect/token")
            {
                Content = new FormUrlEncodedContent(credentials)
            };

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
