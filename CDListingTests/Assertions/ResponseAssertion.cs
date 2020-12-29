using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CDListingTests.Assertions
{
    public static class ResponseAssertion
    {

        public async static void ResponseShouldBeCorrect(HttpResponseMessage response, HttpStatusCode statusCode, bool shouldHaveContent = true, string id = null)
        {
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(statusCode);
                string content = await response.Content.ReadAsStringAsync();
                if (shouldHaveContent)
                {
                    
                    var obj = JsonConvert.DeserializeObject<dynamic>(content);

                    string expectedId = obj.id;
                    id.Should().Be(expectedId);

                    string listingStatus = obj.listingStatus;
                    listingStatus.Should().Be("LISTED");

                }
                else
                {
                    content.Should().BeNullOrEmpty("Response body should not have content");
                    
                }
            }
        }

    }
}
