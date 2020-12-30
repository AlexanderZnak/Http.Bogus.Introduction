using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace CDListingTests.Assertions
{
    public static class ResponseAssertion
    {

        public static void ResponseShouldBeCorrect(HttpResponseMessage response, HttpStatusCode statusCode, string content = null, bool shouldHaveContent = true, string id = null)
        {
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(statusCode);

                if (shouldHaveContent & content != null & id != null)
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
