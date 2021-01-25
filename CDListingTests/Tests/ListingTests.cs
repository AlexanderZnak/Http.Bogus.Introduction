using CDListingTests.Assertions;
using CDListingTests.Services;
using FluentAssertions.Execution;
using Newtonsoft.Json;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace CDListingTests
{
    public class ListingTests
    {
        private readonly ITestOutputHelper OutputHelper;
        private readonly ListingService ListingService;
        private readonly AuthenticationService AuthenticationService;
        private readonly IDependency _dependency;

        public ListingTests(IDependency dependency)
        {
            _dependency = dependency;
            OutputHelper = _dependency.OutputHelper;
            ListingService = new ListingService(OutputHelper.ToLogger<ListingService>());
            AuthenticationService = new AuthenticationService(ListingService);
        }

        [Fact]
        [Trait("Category", "Api")]
        public async void ListingShouldBeRead()
        {
            // Arrange
            var token = await AuthenticationService.GetToken();
            var createListing = await ListingService.CreateListing(token, ListingFactory.GenerateFakeListing().Generate());
            var id = ListingService.ExtractIdFromHeaders(createListing);

            // Act
            var response = await ListingService.GetListing(id, token);
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            ResponseAssertion.ResponseShouldBeCorrect(response, HttpStatusCode.OK, content, id: id);
        }

        [Fact]
        [Trait("Category", "Api")]
        public async void ListingShouldBeUpdated()
        {
            // Arrange
            var token = await AuthenticationService.GetToken();
            var createListing = await ListingService.CreateListing(token, ListingFactory.GenerateFakeListing().Generate());
            var id = ListingService.ExtractIdFromHeaders(createListing);

            // Act
            var response = await ListingService.UpdateListing(id, token, ListingFactory.GenerateFakeListing().Generate());

            // Assert
            ResponseAssertion.ResponseShouldBeCorrect(response, HttpStatusCode.NoContent, shouldHaveContent: false);
        }

        [Fact]
        [Trait("Category", "Api")]
        public async void ListingShouldBeDeleted()
        {
            // Arrange
            var token = await AuthenticationService.GetToken();
            var createListing = await ListingService.CreateListing(token, ListingFactory.GenerateFakeListing().Generate());
            var id = ListingService.ExtractIdFromHeaders(createListing);

            // Act
            var response = await ListingService.DeleteListing(id, token);

            // Assert
            ResponseAssertion.ResponseShouldBeCorrect(response, HttpStatusCode.NoContent, shouldHaveContent: false);
        }

        [Fact]
        [Trait("Category", "Api")]
        public async void ListingShouldBeCreated()
        {
            // Arrange
            var token = await AuthenticationService.GetToken();
            var actualListing = ListingFactory.GenerateFakeListing().Generate();

            // Act
            var postResponse = await ListingService.CreateListing(token, actualListing);
            var id = ListingService.ExtractIdFromHeaders(postResponse);
            var getResponse = await ListingService.GetListing(id, token);
            var expectedListing = JsonConvert.DeserializeObject<ListingHttp>(await getResponse.Content.ReadAsStringAsync());

            // Assert
            using (new AssertionScope())
            {
                ResponseAssertion.ResponseShouldBeCorrect(postResponse, HttpStatusCode.Created, shouldHaveContent: false);
                ListingAssertion.ListingShouldBeCorrect(expectedListing, actualListing);
                ListingAssertion.VehicleShouldBeCorrect(expectedListing.Vehicles, actualListing.Vehicles);
            }
        }

    }
}
