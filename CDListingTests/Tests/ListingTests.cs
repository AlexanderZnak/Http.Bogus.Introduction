using CDListingTests.Assertions;
using CDListingTests.Services;
using FluentAssertions.Execution;
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
        public ListingTests(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            ListingService = new ListingService(OutputHelper.ToLogger<ListingService>());
            AuthenticationService = new AuthenticationService(ListingService);
        }

        [Fact]
        public async void ListingShouldBeCreated()
        {
            //Arrange
            var token = await AuthenticationService.GetToken();

            //Act
            var response = await ListingService.CreateListing(token, ListingFactory.GenerateFakeListing().Generate());

            // Assert
            using (new AssertionScope())
            {
                ResponseAssertion.ResponseShouldBeCorrect(response, HttpStatusCode.Created, shouldHaveContent: false);
            }

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

            // Assert
            using (new AssertionScope())
            {
                ResponseAssertion.ResponseShouldBeCorrect(response, HttpStatusCode.OK, id: id);
            }
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
            using (new AssertionScope())
            {
                ResponseAssertion.ResponseShouldBeCorrect(response, HttpStatusCode.NoContent, shouldHaveContent: false);
            }

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
            using (new AssertionScope())
            {
                ResponseAssertion.ResponseShouldBeCorrect(response, HttpStatusCode.NoContent, shouldHaveContent: false);
            }

        }

    }
}
